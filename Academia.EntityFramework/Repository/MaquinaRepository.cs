using Academia.Entity;
using Academia.Entity.Interfaces;
using Academia.EntityFramework.Model;
using System.Linq;

namespace Academia.EntityFramework.Repository
{
    public class MaquinaRepository : RepositoryBase<Maquina, AcademiaModelContext>
    {
        #region Construtores

        public MaquinaRepository() : base(new AcademiaModelContext()) { }

        #endregion

        #region Métodos Protegidos

        protected override void SetWhereClauses(IFilter<Maquina> filter)
        {
            var filtro = filter as MaquinaFilter;

            if (filtro.Id.HasValue)
            {
                Query = Query.Where(x => x.Id == filtro.Id.Value);
            }

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                if (!string.IsNullOrEmpty(filtro.OrImagem))
                {
                    Query = Query.Where(x => x.Imagem.ToUpper() == filtro.OrImagem.ToUpper() || x.Nome.ToUpper() == filtro.Imagem.ToUpper());
                }
                else
                {
                    Query = Query.Where(x => x.Nome.ToUpper() == filtro.Nome.ToUpper());
                }
            }

            if (!string.IsNullOrEmpty(filtro.Imagem))
            {
                Query = Query.Where(x => x.Imagem.ToUpper() == filtro.Imagem.ToUpper());
            }

            if (filtro.Ativo.HasValue)
            {
                Query = Query.Where(x => x.Ativo == filtro.Ativo.Value);
            }
        }

        #endregion
    }
}
