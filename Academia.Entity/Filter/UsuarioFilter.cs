using Academia.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Academia.Entity
{
    public class UsuarioFilter : IFilter<Usuario>
    {
        #region Construtores

        public UsuarioFilter()
        {
            Includes = new List<Expression<Func<Usuario, object>>>();
        }

        #endregion

        #region Propriedades Públicas

        public int? Id { get; set; }

        public string NomeCompleto { get; set; }

        public string Cpf { get; set; }

        public DateTime? DataNascimento { get; set; }

        public bool? Ativo { get; set; }

        public int? AdicionadoPor { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        #endregion
    }
}
