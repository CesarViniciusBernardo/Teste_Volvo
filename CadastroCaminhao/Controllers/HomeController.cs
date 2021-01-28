using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCaminhao.Models;
using CadastroCaminhao.Negocio;

namespace CadastroCaminhao.Controllers
{
    public class HomeController : Controller
    {
        private CadastroCaminhaoContext cadastroCaminhaoContext;
        public HomeController(CadastroCaminhaoContext cc)
        {
            cadastroCaminhaoContext = cc;
        }
        public IActionResult Index()
        {
            return View(cadastroCaminhaoContext.Caminhao);
        }

        public IActionResult Create(bool IsSuccess = false)
        {
            ViewBag.IsSuccess = IsSuccess;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                var caminhaoNegocio = new CaminhaoNegocio();
                if (caminhaoNegocio.ValidarModeloCaminhao(caminhao))
                {
                    if (caminhaoNegocio.ValidarAnoModelo(caminhao))
                    {
                        cadastroCaminhaoContext.Caminhao.Add(caminhao);
                        cadastroCaminhaoContext.SaveChanges();
                        return RedirectToAction("Create", new { IsSuccess = true });
                    }
                    return RedirectToAction("Create", new { IsSuccess = false });
                }
                else
                    return RedirectToAction("Create", new { IsSuccess = false });
            }
            return RedirectToAction("Create", new { IsSuccess = false });
        }

        public IActionResult Update(int id)
        {
            return View(cadastroCaminhaoContext.Caminhao.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                var caminhaoNegocio = new CaminhaoNegocio();
                if (caminhaoNegocio.ValidarModeloCaminhao(caminhao))
                {
                    if (caminhaoNegocio.ValidarAnoModelo(caminhao))
                    {
                        cadastroCaminhaoContext.Caminhao.Update(caminhao);
                        cadastroCaminhaoContext.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View();
                }
                else
                    return View();
            }
            return View();
    }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var teacher = cadastroCaminhaoContext.Caminhao.Where(a => a.Id == id).FirstOrDefault();
            cadastroCaminhaoContext.Caminhao.Remove(teacher);
            cadastroCaminhaoContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
