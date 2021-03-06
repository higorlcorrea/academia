using System;
using System.Collections.Generic;

namespace Academia.Entity
{
    [Serializable]
    public class Usuario
    {
        public Usuario()
        {
            this.Treinos = new List<Treino>();
            this.TreinosCriados = new List<Treino>();
            this.Cargos = new List<Cargo>();
        }
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        public int? AdicionadoPor { get; set; }

        public virtual List<Treino> Treinos { get; set; }

        public virtual List<Treino> TreinosCriados { get; set; }

        public virtual List<Cargo> Cargos { get; set; }

        public virtual Usuario CriadoPor { get; set; }

    }
}
