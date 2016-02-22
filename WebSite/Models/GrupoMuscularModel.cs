using Academia.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class GrupoMuscularModel
    {
        #region Propriedades Públicas

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo Nome deve conter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        #endregion

    }
}
