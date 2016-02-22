using System;
using System.Collections.Generic;

namespace Academia.Entity
{
    public class Exercicio
    {
        public Exercicio()
        {
        }
        public int Id { get; set; }

        public int? IdMaquina { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual Maquina Maquina { get; set; }

        public virtual GrupoMuscular GruposMusculares { get; set; }
    }
}
