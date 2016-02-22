using Academia.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class GrupoMuscularModel
    {
        #region Propriedades P�blicas

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome � obrigat�rio.")]
        [StringLength(150, ErrorMessage = "O campo Nome deve conter no m�ximo 150 caracteres.")]
        public string Nome { get; set; }

        #endregion

    }
}
