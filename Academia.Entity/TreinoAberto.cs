using System;
using System.Collections.Generic;

namespace Academia.Entity
{
    public class TreinoAberto
    {
        public TreinoAberto()
        {
            ExerciciosRealizados = new List<Exercicio>();
        }

        public int Id { get; set; }
        public int IdTreino { get; set; }
        public DateTime DataAbertura { get; set; }

        public virtual Treino Treino { get; set; }
        public virtual List<Exercicio> ExerciciosRealizados { get; set; }
    }
}
