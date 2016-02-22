using Academia.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Academia.Entity
{
    public class CargoFilter : IFilter<Cargo>
    {
        
        #region Construtores

        public CargoFilter()
        {
            Includes = new List<Expression<Func<Cargo, object>>>();
        }

        #endregion

        #region Propriedades Públicas

        public int? Id { get; set; }

        public string Nome { get; set; }

        public bool? Ativo { get; set; }

        #endregion
    }
}
