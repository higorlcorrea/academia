using Academia.Entity;
using Academia.Entity.Interfaces;
using Academia.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.EntityFramework.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario, AcademiaModelContext>
    {
        #region Construtores

        public UsuarioRepository() : base(new AcademiaModelContext()) { }

        #endregion

        #region Métodos Protegidos

        protected override void SetWhereClauses(IFilter<Usuario> filter)
        {
            var filtro = filter as UsuarioFilter;

            if (filtro.AdicionadoPor.HasValue)
            {
                Query = Query.Where(x => x.AdicionadoPor == filtro.AdicionadoPor.Value);
            }

            if (filtro.Ativo.HasValue)
            {
                Query = Query.Where(x => x.Ativo == filtro.Ativo.Value);
            }

            if (filtro.DataNascimento.HasValue)
            {
                Query = Query.Where(x => x.DataNascimento == filtro.DataNascimento.Value);
            }

            if (filtro.Id.HasValue)
            {
                Query = Query.Where(x => x.Id == filtro.Id.Value);
            }

            if (!string.IsNullOrEmpty(filtro.Cpf))
            {
                Query = Query.Where(x => x.Cpf == filtro.Cpf);
            }
            
            if (!string.IsNullOrEmpty(filtro.NomeCompleto))
            {
                Query = Query.Where(x => x.NomeCompleto == filtro.NomeCompleto);
            }

            if (!string.IsNullOrEmpty(filtro.Login))
            {
                Query = Query.Where(x => x.Login == filtro.Login);
            }

            if (!string.IsNullOrEmpty(filtro.Senha))
            {
                Query = Query.Where(x => x.Senha == filtro.Senha);
            }
        }

        #endregion
    }
}
