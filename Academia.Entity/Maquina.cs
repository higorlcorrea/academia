using System;
using System.Collections.Generic;

namespace Academia.Entity
{
    public class Maquina
    {
        public Maquina()
        {
        }
        
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        public bool Ativo { get; set; }
    }
}
