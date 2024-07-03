using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BSTWebApp.Models;

namespace BSTWebApp.Controllers
{
    public class ArbolController : Controller
    {
        private static ArbolBinario<int> arbol = new ArbolBinario<int>();
        public ActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            ViewBag.ResultadoBusqueda = null;

            return View();
        }
        [HttpPost]
        public ActionResult Insertar(int numero)
        {
            arbol.Insertar(numero);

            return RedirectToAction("Index", new { mensaje = "Número insertado correctamente en el árbol." });
        }

    }
}
