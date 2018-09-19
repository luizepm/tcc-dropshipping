using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcc_UI.Helpers;

namespace tcc_UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var lojaApi = new LojaApi();
                var login = lojaApi.ValidarLogin(model.Email, Encrypt.EncryptValue(model.Senha));

                if (login != null)
                    Session["Login"] = model;
                else
                {
                    ViewBag.MensagemErroLogin = "Usuário e/ou senha inválidos.";
                    return View(model);
                }
            }
            else
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AcessoNegado()
        {
            return View();
        }

        public ActionResult Sair()
        {
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
