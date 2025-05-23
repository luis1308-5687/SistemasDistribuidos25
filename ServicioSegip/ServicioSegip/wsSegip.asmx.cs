using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioSegip
{
    /// <summary>
    /// Descripción breve de wsSegip
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsSegip : System.Web.Services.WebService
    {
        private static List<Persona> personas = new List<Persona>
        {
            new Persona { CI = "123", Nombres = "pepe", PrimerApellido = "cuenca", SegundoApellido = "rios" },
            new Persona { CI = "246810", Nombres = "Eric", PrimerApellido = "Barrios", SegundoApellido = "Gonzales" }
        };
        [WebMethod]
        public bool VerificarDatos(string ci, string nombres, string primerApellido, string segundoApellido)
        {
            var persona = personas.Find(p => p.CI == ci);
            return persona != null &&
                   persona.Nombres == nombres &&
                   persona.PrimerApellido == primerApellido &&
                   persona.SegundoApellido == segundoApellido;
        }

        [WebMethod]
        public Persona ObtenerDatos(string ci)
        {
            return personas.Find(p => p.CI == ci);
        }
    }
}
