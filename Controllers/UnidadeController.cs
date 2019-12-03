using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalUniversitario.Models;
using PortalUniversitario.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalUniversitario.Controllers
{
    public class UnidadeController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new UnidadeData())
                return View(data.Read());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Unidade e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);
            }

            using (var data = new UnidadeData())
                data.Create(e);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using (var data = new UnidadeData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new UnidadeData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Unidade e)
        {
            e.IdUnidade = id;

            if (!ModelState.IsValid)
                return View(e);

            using (var data = new UnidadeData())
                data.Update(e);

            return RedirectToAction("Index");
        }



    }
}