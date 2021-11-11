using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Data
{
    public class VuelosInitializer : DropCreateDatabaseAlways<DbVueloContext>
    {
        protected override void Seed(DbVueloContext context)
        {
            var vuelos = new List<Vuelo>
            {
               new Vuelo {
                  Fecha = new DateTime(2021,10,11),
                  Destino = "París",
                  Origen = "Buenos Aires",
                  Matricula = 154
               },
                
               new Vuelo {
                  Fecha = new DateTime(2020,5,12),
                  Destino = "Madrid",
                  Origen = "París",
                  Matricula = 587
               },  
               
               new Vuelo {
                  Fecha = new DateTime(2021,11,30),
                  Destino = "Florida",
                  Origen = "Buenos Aires",
                  Matricula = 785
               },
                
               new Vuelo {
                  Fecha = new DateTime(2020,10,22),
                  Destino = "Madrid",
                  Origen = "Buenos Aires",
                  Matricula = 369
               }
            };
            vuelos.ForEach(s => context.Vuelos.Add(s));
            context.SaveChanges();
        }
    }
}