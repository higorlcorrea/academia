using Academia.Business.Business;
using Academia.Entity;
using Academia.Entity.Constantes;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebSite.ActionFilter;
using WebSite.Mappers;
using WebSite.Models;

namespace WebSite.Controllers
{
    [SystemFilter]
    public class GrupoMuscularController : Controller
    {
        #region Propriedades Protegidas

        public GrupoMuscularBusiness _grupoMuscularBusiness { get; set; }

        #endregion

        #region Construtores

        public GrupoMuscularController()
        {
            _grupoMuscularBusiness = new GrupoMuscularBusiness();
        }

        #endregion

        #region Métodos Públicos

        public ActionResult Index()
        {
            List<GrupoMuscularModel> lista = new List<GrupoMuscularModel>();
            try
            {
                var listaGrupo = _grupoMuscularBusiness.Listar();
                listaGrupo.ForEach(grupo =>
                {
                    lista.Add(SimpleMapper.Map<GrupoMuscular, GrupoMuscularModel>(grupo));
                });
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
            }

            return View(lista);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(GrupoMuscularModel grupoMuscularModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var grupoMuscular = SimpleMapper.Map<GrupoMuscularModel, GrupoMuscular>(grupoMuscularModel);

                    _grupoMuscularBusiness.Inserir(grupoMuscular);

                    TempData["Sucesso"] = Mensagens.CADASTRO_SUCESSO;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            return View(grupoMuscularModel);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            GrupoMuscularModel model = null;

            try
            {
                var grupoMuscular = _grupoMuscularBusiness.Obter(id);
                model = SimpleMapper.Map<GrupoMuscular, GrupoMuscularModel>(grupoMuscular);

            }
            catch (Exception e)
            {
                TempData["Erro"] = e.Message;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(GrupoMuscularModel grupoMuscularModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var grupoMuscular = SimpleMapper.Map<GrupoMuscularModel, GrupoMuscular>(grupoMuscularModel);

                    _grupoMuscularBusiness.Editar(grupoMuscular);

                    TempData["Sucesso"] = Mensagens.EDICAO_SUCESSO;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            return View(grupoMuscularModel);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            try
            {
                _grupoMuscularBusiness.Excluir(id);
                TempData["Sucesso"] = Mensagens.EXCLUSAO_SUCESSO;
            }
            catch (Exception e)
            {
                TempData["Erro"] = e.Message;
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}