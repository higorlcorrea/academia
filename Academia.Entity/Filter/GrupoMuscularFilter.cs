using Academia.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Academia.Entity
{
    public class GrupoMuscularFilter : IFilter<GrupoMuscular>
    {

        #region Construtores

        public GrupoMuscularFilter()
        {
            Includes = new List<Expression<Func<GrupoMuscular, object>>>();

        }

        #endregion

        #region Propriedades Públicas

        public int? Id { get; set; }

        public string Nome { get; set; }

        #endregion
    }
}
