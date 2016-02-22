using Academia.Entity;
using System.Collections.Generic;

namespace WebSite.Models
{

    public class TreinoModel
    {
        #region Construtores

        public TreinoModel()
        {
            this.TreinosAbertos = new List<TreinoAberto>();
            this.Exercicios = new List<Exercicio>();
        }

        #endregion

        #region Propriedades Públicas

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

        #endregion
    }
}
