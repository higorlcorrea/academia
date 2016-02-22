using Academia.Entity;
using System.Web;

namespace WebSite.Models
{
    public static class UsuarioSession
    {
        #region Métodos Estáticos Públicos

        public static Usuario GetSession()
        {
            return HttpContext.Current.Session["UsuarioLogado"] as Usuario;
        }

        public static void SetSession(Usuario usuarioLogado)
        {
            HttpContext.Current.Session["UsuarioLogado"] = usuarioLogado;
        }

        public static string GetNome()
        {
            var usuario = HttpContext.Current.Session["UsuarioLogado"] as Usuario;
            var nomes = usuario.NomeCompleto.Split(' ');

            return nomes[0] + " " + nomes[nomes.Length - 1];
        }

        #endregion
    }
}