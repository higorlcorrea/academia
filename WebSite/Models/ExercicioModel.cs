using Academia.Entity;

namespace WebSite.Models
{
    public class ExercicioModel
    {
        
        #region Propriedades Públicas

        public int Id { get; set; }

        public int? IdMaquina { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual Maquina Maquina { get; set; }

        public virtual GrupoMuscular GruposMusculares { get; set; }

        #endregion
    }
}
