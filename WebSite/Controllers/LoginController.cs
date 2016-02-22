using Academia.Entity;
using Academia.Business;
using System;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Mappers;
using System.Web;
using WebSite.ActionFilter;

namespace WebSite.Controllers
{
    public class LoginController : Controller
    {
        #region Propriedades Protegidas

        public LoginBusiness _loginBusiness { get; set; }

        #endregion

        #region Construtores

        public LoginController()
        {
            _loginBusiness = new LoginBusiness();
        }

        #endregion

        #region Métodos Públicos

        [SystemFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [SystemFilter]
        public ActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var login = SimpleMapper.Map<LoginModel, Login>(loginModel);
                    var usuarioLogado = _loginBusiness.ValidarLogin(login);

                    UsuarioSession.SetSession(usuarioLogado);

                    if (loginModel.ManterLogado)
                    {
                        var cookie = new HttpCookie("UsuarioLogado");
                        cookie.Value = usuarioLogado.Id.ToString();
                        cookie.Expires = DateTime.Now.AddDays(5);

                        Response.Cookies.Add(cookie);
                    }

                    return RedirectToAction("Index", "GrupoMuscular");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(loginModel);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            var cookie = Response.Cookies["UsuarioLogado"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}