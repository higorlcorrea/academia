using Academia.Entity;
using Academia.EntityFramework.Model;
using System.Linq;
using System.Data.Entity;
using Academia.Entity.Interfaces;

namespace Academia.EntityFramework.Repository
{
    public class GrupoMuscularRepository : RepositoryBase<GrupoMuscular, AcademiaModelContext>
    {

        #region Construtores

        public GrupoMuscularRepository() : base(new AcademiaModelContext()) { }

        #endregion

        #region Métodos Protegidos

        protected override void SetWhereClauses(IFilter<GrupoMuscular> filter)
        {
            var filtro = filter as GrupoMuscularFilter;

            if (filtro.Id.HasValue)
            {
                Query = Query.Where(x => x.Id == filtro.Id.Value);
            }

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                Query = Query.Where(x => x.Nome.ToUpper() == filtro.Nome.ToUpper());
            }
        }

        #endregion

    }
}
