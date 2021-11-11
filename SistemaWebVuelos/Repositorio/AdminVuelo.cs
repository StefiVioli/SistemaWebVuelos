using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Repositorio
{
    public class AdminVuelo
    {
        private static DbVueloContext context = new DbVueloContext();


        //Listar todos
        public static List<Vuelo> Listar()
        {
            var vuelos = context.Vuelos.ToList();
            return vuelos;
        }

        //Carga
        public static void Cargar(Vuelo vuelo)
        {
            context.Vuelos.Add(vuelo);
            context.SaveChanges();
        }

        //Modificación
        public static void Modificar(Vuelo vuelo)
        {
            context.Vuelos.Attach(vuelo);
            context.Entry(vuelo).State = EntityState.Modified;
            context.SaveChanges();
        }

        public static Vuelo BuscarVueloId(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            context.Entry(vuelo).State = EntityState.Detached;
            return vuelo;
        }


        //Eliminación
        public static void Eliminar(Vuelo vuelo)
        {
            context.Vuelos.Attach(vuelo);
            context.Vuelos.Remove(vuelo);
            context.SaveChanges();
        }

        public static List<Vuelo> TraerPorDestino(string destino)
        {
            List<Vuelo> vuelosDestino = (from v in context.Vuelos
                                         where v.Destino == destino
                                         select v).ToList();
            return vuelosDestino;
        }
    }
}