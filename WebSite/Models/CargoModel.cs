using Academia.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class CargoModel
    {
        #region Construtores

        public CargoModel()
        {
            this.Usuarios = new List<Usuario>();
        }

        #endregion

        #region Propriedades Públicas

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve conter no máximo 50 caracteres.")]
        public string Nome { get; set; }
        
        public bool Ativo { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }

        #endregion
    }
}
