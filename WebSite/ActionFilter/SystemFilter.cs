using Academia.Business;
using Academia.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using WebSite.Models;

namespace WebSite.ActionFilter
{
    public class SystemFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var telaLogIn = request.Path.Contains("Login");
            var logOff = request.Path.Contains("Logout");
            if (telaLogIn && UsuarioSession.GetSession() != null && !logOff)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "GrupoMuscular" }, { "action", "Index" } });
            }
            else
            {
                if (UsuarioSession.GetSession() == null && !logOff)
                {
                    var cookie = request.Cookies["UsuarioLogado"];
                    Usuario usuario = null;

                    if (cookie != null)
                    {
                        var idUsuarioStr = cookie.Value;
                        var idUsuario = 0;
                        if (int.TryParse(idUsuarioStr, out idUsuario))
                        {
                            var usuarioBusiness = new UsuarioBusiness();
                            usuario = usuarioBusiness.Obter(idUsuario);
                        }
                    }

                    if (usuario == null && !telaLogIn)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                    }
                    else
                    {
                        UsuarioSession.SetSession(usuario);
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}