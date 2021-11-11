using SistemaWebVuelos.Data;
using SistemaWebVuelos.Filters;
using SistemaWebVuelos.Models;
using SistemaWebVuelos.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Controllers
{
    [MyFilterAction]
    public class VueloController : Controller
    {


        //Crear instancia del dbcontext

        private DbVueloContext context = new DbVueloContext();
        // GET: Vuelo
        public ActionResult Index()
        {   
            var vuelos = AdminVuelo.Listar();
            //el controller retorna una vista "Index" con la lista de Vuelos
            return View("Index", vuelos);
        }

        [HttpGet]
        public ActionResult Create()
        {

            Vuelo vuelo = new Vuelo();


            return View("Create", vuelo);
        }


        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                AdminVuelo.Cargar(vuelo);
                return RedirectToAction("Index");
            }

            return View("Create", vuelo);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Vuelo vuelo = AdminVuelo.BuscarVueloId(id);


            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Vuelo vuelo = AdminVuelo.BuscarVueloId(id);


            if (vuelo != null)
            {
                return View("Delete", vuelo);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo vuelo = AdminVuelo.BuscarVueloId(id);

            if (vuelo != null)
            {
                AdminVuelo.Eliminar(vuelo);
            }

            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult BuscarPorDestino(string destino)
        {
            if (destino == "" || destino == "TODOS")
            {
                return RedirectToAction("Index");
            }

            return View("Index", AdminVuelo.TraerPorDestino(destino));
         
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = AdminVuelo.BuscarVueloId(id);

            if (vuelo != null)
            {
                return View("Edit", vuelo);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Vuelo vuelo)
            
        {

            if (ModelState.IsValid)
            {
                AdminVuelo.Modificar(vuelo);
                return RedirectToAction("Index");
            }

            return View("Edit", vuelo);

        }
    }
}
