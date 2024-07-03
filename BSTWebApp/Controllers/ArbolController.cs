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
            ViewBag.Records = ObtenerRecorridos();
            ViewBag.Minimo = arbol.Raiz != null ? arbol.Minimo().ToString() : "Árbol vacío";
            ViewBag.Maximo = arbol.Raiz != null ? arbol.Maximo().ToString() : "Árbol vacío";

            return View();
        }
        [HttpPost]
        public ActionResult Insertar(int numero)
        {
            arbol.Insertar(numero);

            return RedirectToAction("Index", new { mensaje = "Número insertado correctamente en el árbol." });
        }

        public ActionResult Buscar(int numero)
        {
            var encontrado = arbol.Buscar(numero);
            if (encontrado != null)
            {
                ViewBag.ResultadoBusqueda = encontrado.Valor;
                ViewBag.Mensaje = $"Se encontró el número {numero}.";
            }
            else
            {
                ViewBag.ResultadoBusqueda = null;
                ViewBag.Mensaje = $"No se encontró el número {numero}.";
            }

            ViewBag.Records = ObtenerRecorridos();
            ViewBag.Minimo = arbol.Raiz != null ? arbol.Minimo().ToString() : "Árbol vacío";
            ViewBag.Maximo = arbol.Raiz != null ? arbol.Maximo().ToString() : "Árbol vacío";
            return View("Index");
        }

        [HttpPost]
        public ActionResult Eliminar(int numero)
        {
            var encontrado = arbol.Buscar(numero);
            if (encontrado == null)
            {
                return RedirectToAction("Index", new { mensaje = $"No se encontró el número {numero} para eliminar." });
            }

            arbol.Eliminar(numero);

            return RedirectToAction("Index", new { mensaje = $"Se ha eliminado el número {numero}." });
        }

        [HttpPost]
        public ActionResult ObtenerMinimo()
        {
            ViewBag.MinMaxTitle = "MÍNIMO ";
            ViewBag.MinMaxValue = arbol.Raiz != null ? arbol.Minimo().ToString() : "Árbol vacío";
            ViewBag.Records = ObtenerRecorridos();
            return View("Index");
        }

        [HttpPost]
        public ActionResult ObtenerMaximo()
        {
            ViewBag.MinMaxTitle = "MÁXIMO ";
            ViewBag.MinMaxValue = arbol.Raiz != null ? arbol.Maximo().ToString() : "Árbol vacío";
            ViewBag.Records = ObtenerRecorridos();
            return View("Index");
        }

        // Método para obtener los recorridos del árbol
        private Dictionary<string, List<string>> ObtenerRecorridos()
        {
            var inOrden = arbol.InOrden();
            var preOrden = arbol.PreOrden();
            var postOrden = arbol.PostOrden();

            return new Dictionary<string, List<string>>()
     {
         { "InOrden", inOrden.ConvertAll(n => n.ToString()) },
         { "PreOrden", preOrden.ConvertAll(n => n.ToString()) },
         { "PostOrden", postOrden.ConvertAll(n => n.ToString()) },
     };
        }

    }
}
