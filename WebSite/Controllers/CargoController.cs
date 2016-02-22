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
    public class CargoController : Controller
    {
        #region Propriedades Protegidas

        public CargoBusiness _CargoBusiness { get; set; }

        #endregion

        #region Construtores

        public CargoController()
        {
            _CargoBusiness = new CargoBusiness();
        }

        #endregion

        #region Métodos Públicos

        public ActionResult Index()
        {
            List<CargoModel> lista = new List<CargoModel>();
            try
            {
                var listaGrupo = _CargoBusiness.Listar();
                listaGrupo.ForEach(grupo =>
                {
                    lista.Add(SimpleMapper.Map<Cargo, CargoModel>(grupo));
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
        public ActionResult Novo(CargoModel CargoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Cargo = SimpleMapper.Map<CargoModel, Cargo>(CargoModel);

                    _CargoBusiness.Inserir(Cargo);

                    TempData["Sucesso"] = Mensagens.CADASTRO_SUCESSO;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            return View(CargoModel);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            CargoModel model = null;

            try
            {
                var Cargo = _CargoBusiness.Obter(id);
                model = SimpleMapper.Map<Cargo, CargoModel>(Cargo);

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
        public ActionResult Editar(CargoModel CargoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Cargo = SimpleMapper.Map<CargoModel, Cargo>(CargoModel);

                    _CargoBusiness.Editar(Cargo);

                    TempData["Sucesso"] = Mensagens.EDICAO_SUCESSO;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            return View(CargoModel);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            try
            {
                _CargoBusiness.Excluir(id);
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