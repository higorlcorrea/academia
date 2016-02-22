using Academia.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Academia.Entity
{
    public class MaquinaFilter : IFilter<Maquina>
    {
        #region Construtores

        public MaquinaFilter()
        {
            Includes = new List<Expression<Func<Maquina, object>>>();
        }

        #endregion

        #region Propriedades Públicas

        public int? Id { get; set; }

        public string Nome { get; set; }

        public string OrImagem { get; set; }

        public string Imagem { get; set; }

        public bool? Ativo { get; set; }

        #endregion
    }
}
