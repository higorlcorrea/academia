using Academia.Business.Business;
using Academia.Entity;
using Academia.Entity.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.ActionFilter;
using WebSite.Mappers;
using WebSite.Models;

namespace WebSite.Controllers
{
    [SystemFilter]
    public class MaquinaController : Controller
    {
        #region Propriedades Protegidas

        public MaquinaBusiness _maquinaBusiness { get; set; }

        #endregion

        #region Construtores

        public MaquinaController()
        {
            _maquinaBusiness = new MaquinaBusiness();
        }

        #endregion

        #region Métodos Públicos

        public ActionResult Index()
        {
            //Somente testando o push do github...
            List<MaquinaModel> lista = new List<MaquinaModel>();
            try
            {
                var listaGrupo = _maquinaBusiness.Listar();
                listaGrupo.ForEach(grupo =>
                {
                    lista.Add(SimpleMapper.Map<Maquina, MaquinaModel>(grupo));
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
        public ActionResult Novo(MaquinaModel MaquinaModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Maquina = SimpleMapper.Map<MaquinaModel, Maquina>(MaquinaModel);

                    _maquinaBusiness.Inserir(Maquina);

                    TempData["Sucesso"] = Mensagens.CADASTRO_SUCESSO;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            return View(MaquinaModel);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            MaquinaModel model = null;

            try
            {
                var Maquina = _maquinaBusiness.Obter(id);
                model = SimpleMapper.Map<Maquina, MaquinaModel>(Maquina);

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
        public ActionResult Editar(MaquinaModel MaquinaModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Maquina = SimpleMapper.Map<MaquinaModel, Maquina>(MaquinaModel);

                    _maquinaBusiness.Editar(Maquina);

                    TempData["Sucesso"] = Mensagens.EDICAO_SUCESSO;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            return View(MaquinaModel);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            try
            {
                _maquinaBusiness.Excluir(id);
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