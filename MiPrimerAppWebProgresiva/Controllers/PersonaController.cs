using Microsoft.AspNetCore.Mvc;
using MiPrimerAppWebProgresiva.Clases;
using MiPrimerAppWebProgresiva.Models;

namespace MiPrimerAppWebProgresiva.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<PersonaCLS> ListaPersonas(string nombreCompleto){
            List<PersonaCLS> Lista = new List<PersonaCLS>();
            using(db_a8e245_bdbibliotecaContext bd = 
                new db_a8e245_bdbibliotecaContext()){
                if (nombreCompleto == null)
                {
                    Lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             select new PersonaCLS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombreCompleto = persona.Nombre + "" +
                                                  persona.Appaterno + "" +
                                                  persona.Apmaterno,
                                 correo = persona.Correo
                             }).ToList();

                }
                else {
                    Lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             &&(persona.Nombre + "" + persona.Appaterno + "" + persona.Apmaterno).Contains(nombreCompleto)
                             select new PersonaCLS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombreCompleto = persona.Nombre + "" +
                                                  persona.Appaterno + "" +
                                                  persona.Apmaterno,
                                 correo = persona.Correo


                             }).ToList();
                } 
                return Lista;
                
            }
        }
    }
}
