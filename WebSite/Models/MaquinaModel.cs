
using System.ComponentModel.DataAnnotations;
namespace WebSite.Models
{
    public class MaquinaModel
    {

        #region Propriedades Públicas

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo Nome deve conter no máximo 30 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Imagem (70x70)")]
        [Required(ErrorMessage = "O campo Imagem é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo nome da Imagem deve conter no máximo 200 caracteres.")]
        public string Imagem { get; set; }

        public bool Ativo { get; set; }

        #endregion

    }
}
