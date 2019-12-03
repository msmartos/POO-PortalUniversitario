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
    public class UniversidadeController : Controller
    {
        public IActionResult Index()
        {
            using (var data = new UniversidadeData())
                return View(data.Read());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Universidade e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);
            }

            using (var data = new UniversidadeData())
                data.Create(e);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using (var data = new UniversidadeData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new UniversidadeData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Universidade e)
        {
            e.IdUniversidade = id;

            if (!ModelState.IsValid)
                return View(e);

            using (var data = new UniversidadeData())
                data.Update(e);

            return RedirectToAction("Index");
        }

    }
}