
using System.ComponentModel.DataAnnotations;
namespace WebSite.Models
{
    public class MaquinaModel
    {

        #region Propriedades P�blicas

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome � obrigat�rio.")]
        [StringLength(30, ErrorMessage = "O campo Nome deve conter no m�ximo 30 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Imagem (70x70)")]
        [Required(ErrorMessage = "O campo Imagem � obrigat�rio.")]
        [StringLength(200, ErrorMessage = "O campo nome da Imagem deve conter no m�ximo 200 caracteres.")]
        public string Imagem { get; set; }

        public bool Ativo { get; set; }

        #endregion

    }
}
