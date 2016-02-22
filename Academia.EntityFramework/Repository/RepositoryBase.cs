using Academia.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Academia.Entity.Interfaces;

namespace Academia.EntityFramework.Repository
{
    public class RepositoryBase<T, Y> : IDisposable
        where T : class
        where Y : DbContext
    {
        #region Propriedades Privadas

        private DbSet<T> InnerDbSet { get; set; }

        private Y Context { get; set; }

        #endregion

        #region Propriedades Protegidas

        protected IQueryable<T> Query { get; set; }

        #endregion

        #region Construtores

        public RepositoryBase(Y context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("O modelo de dados está vazio.");
            }
            this.Context = context;
            this.Query = context.Set<T>().AsNoTracking().AsQueryable();
            this.InnerDbSet = Context.Set<T>();
        }

        #endregion

        #region Métodos Públicos

        public void Inserir(T entity)
        {
            InnerDbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Inserir(List<T> entities)
        {
            entities.ForEach(entity =>
            {
                InnerDbSet.Add(entity);
            });

            Context.SaveChanges();
        }

        public void Editar(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                InnerDbSet.Attach(entity);
            }

            Context.Entry(entity).State = EntityState.Modified;

            Context.SaveChanges();
        }

        public void Editar(List<T> entities)
        {
            entities.ForEach(entity =>
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    InnerDbSet.Attach(entity);
                }

                Context.Entry(entity).State = EntityState.Modified;

            });

            Context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var entity = InnerDbSet.Find(id);

            InnerDbSet.Remove(entity);

            Context.SaveChanges();
        }

        public void Excluir(T entity)
        {
            InnerDbSet.Remove(entity);

            Context.SaveChanges();
        }

        public void Excluir(List<T> entities)
        {
            entities.ForEach(entity =>
            {
                InnerDbSet.Remove(entity);
            });

            Context.SaveChanges();
        }

        public T Obter(int id)
        {
            return InnerDbSet.Find(id);
        }

        public List<T> ListarComFiltro(IFilter<T> filter)
        {
            SetWhereClauses(filter);

            SetIncludeClauses(filter);

            return Query.ToList();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion

        #region Métodos Protegidos

        protected virtual void SetWhereClauses(IFilter<T> filter){}

        private void SetIncludeClauses(IFilter<T> filter)
        {
            if (filter != null)
            {

                if (filter.Includes != null && filter.Includes.Count > 0)
                {
                    filter.Includes.ForEach(x => { Query = Query.Include(x); });
                }

            }
        }

        #endregion

    }
}
