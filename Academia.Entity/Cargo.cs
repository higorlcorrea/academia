using System;
using System.Collections.Generic;

namespace Academia.Entity
{
    public class Cargo
    {
        public Cargo()
        {
            this.Usuarios = new List<Usuario>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }
    }
}
