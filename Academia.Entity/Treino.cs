using System;
using System.Collections.Generic;

namespace Academia.Entity
{

    public class Treino
    {
        public Treino()
        {
            this.TreinosAbertos = new List<TreinoAberto>();
            this.Exercicios = new List<Exercicio>();
        }

        public int Id { get; set; }
        public int IdUsuarioAluno { get; set; }
        public int IdUsuarioCriacao { get; set; }
        public int? IdCategoriaTreino { get; set; }
        public string Descricao { get; set; }
        public DiasSemanaEnum? DiaSemana { get; set; }

        public virtual CategoriaTreino CategoriaTreino { get; set; }
        public virtual Usuario Aluno { get; set; }
        public virtual Usuario Personal { get; set; }
        public virtual List<TreinoAberto> TreinosAbertos { get; set; }
        public virtual List<Exercicio> Exercicios { get; set; }
    }
}
