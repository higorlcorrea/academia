using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class LoginModel
    {
        #region Propriedades Públicas

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo Usuário deve conter no máximo 20 caracteres.")]
        public string User { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo Senha deve conter no máximo 20 caracteres")]
        public string Password { get; set; }

        public bool ManterLogado { get; set; }

        #endregion
    }
}