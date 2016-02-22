using Academia.Entity;
using System;
using System.Collections.Generic;

namespace WebSite.Models
{
    public class TreinoAbertoModel
    {
        #region Construtores

        public TreinoAbertoModel()
        {
            ExerciciosRealizados = new List<Exercicio>();
        }

        #endregion

        #region Propriedades Públicas

        public int Id { get; set; }

        public int IdTreino { get; set; }

        public DateTime DataAbertura { get; set; }

        public virtual Treino Treino { get; set; }

        public virtual List<Exercicio> ExerciciosRealizados { get; set; }

        #endregion
    }
}
