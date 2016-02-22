using Academia.Entity;
using Academia.Entity.Interfaces;
using Academia.EntityFramework.Model;
using System.Linq;

namespace Academia.EntityFramework.Repository
{
    public class CargoRepository : RepositoryBase<Cargo, AcademiaModelContext>
    {
        #region Construtores

        public CargoRepository() : base(new AcademiaModelContext()) { }

        #endregion

        #region Métodos Protegidos

        protected override void SetWhereClauses(IFilter<Cargo> filter)
        {
            var filtro = filter as CargoFilter;

            if (filtro.Id.HasValue)
            {
                Query = Query.Where(x => x.Id == filtro.Id.Value);
            }

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                Query = Query.Where(x => x.Nome.ToUpper() == filtro.Nome.ToUpper());
            }

            if (filtro.Ativo.HasValue)
            {
                Query = Query.Where(x => x.Ativo == filtro.Ativo.Value);
            }
        }

        #endregion
    }
}
