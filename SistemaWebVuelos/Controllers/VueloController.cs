using SistemaWebVuelos.Data;
using SistemaWebVuelos.Filters;
using SistemaWebVuelos.Models;
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
            //Traer todos los Vuelos usando EF
            var vuelos = context.Vuelos.ToList();

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
                context.Vuelos.Add(vuelo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", vuelo);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);

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
            Vuelo vuelo = context.Vuelos.Find(id);

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
            Vuelo vuelo = context.Vuelos.Find(id);

            context.Vuelos.Remove(vuelo);
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult BuscarPorDestino(string destino)
        {
            if (destino == "" || destino == "TODOS")
            {
                return RedirectToAction("Index");
            }

            List<Vuelo> vuelosDestino = (from v in context.Vuelos
                                                where v.Destino == destino
                                                select v).ToList();

            return View("Index", vuelosDestino);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);

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
                context.Entry(vuelo).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", vuelo);

        }
    }
}
