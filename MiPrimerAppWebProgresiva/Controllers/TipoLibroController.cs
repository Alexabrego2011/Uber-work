using Microsoft.AspNetCore.Mvc;
using MiPrimerAppWebProgresiva.Clases;
using MiPrimerAppWebProgresiva.Models;

namespace MiPrimerAppWebProgresiva.Controllers
{
    public class TipoLibroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TipoLibroCLS> listaTipoLibro(string nombretipolibrobuscar)
        {
            List<TipoLibroCLS> lista = new List<TipoLibroCLS>();
            using (db_a8e245_bdbibliotecaContext bd =
                new db_a8e245_bdbibliotecaContext())
            {
                if (nombretipolibrobuscar == null)
                {
                    lista = (from TipoLibro in bd.TipoLibros
                             where TipoLibro.Bhabilitado == 1
                             select new TipoLibroCLS
                             {
                                 iidtipolibro = TipoLibro.Iidtipolibro,
                                 nombre = TipoLibro.Nombretipolibro,
                                 descripcion = TipoLibro.Descripcion
                             }).ToList();
                }
                else
                {
                    lista = (from TipoLibro in bd.TipoLibros
                             where TipoLibro.Bhabilitado == 1 &&
                             TipoLibro.Nombretipolibro.Contains(nombretipolibrobuscar)
                             select new TipoLibroCLS
                             {
                                 iidtipolibro = TipoLibro.Iidtipolibro,
                                 nombre = TipoLibro.Nombretipolibro,
                                 descripcion = TipoLibro.Descripcion
                             }).ToList();
                }
            }
            return lista;
            }
            public int guardarTipoLibro(TipoLibroCLS objTipoLibroCLS)
            {
            int rpta = 0;
            using (db_a8e245_bdbibliotecaContext bd =
                   new db_a8e245_bdbibliotecaContext ())
            {
                try
                {
                    if (objTipoLibroCLS.iidtipolibro == 0)
                    {
                        TipoLibro objtipoLibro = new TipoLibro();
                        objtipoLibro.Nombretipolibro = objTipoLibroCLS.nombre;
                        objtipoLibro.Descripcion = objTipoLibroCLS.descripcion;
                        bd.TipoLibros.Add(objtipoLibro);
                        bd.SaveChanges();
                        rpta = 1;
                    }
                    else
                    {
                        TipoLibro objtipolibro = bd.TipoLibros.Where
                            (p => p.Iidtipolibro == objTipoLibroCLS.iidtipolibro).First();
                        objtipolibro.Nombretipolibro = objTipoLibroCLS.nombre;
                        objtipolibro.Descripcion = objTipoLibroCLS.descripcion;
                        bd.SaveChanges();
                        rpta = 1;
                    }
                }
                catch (Exception ex)
                {
                    rpta = 0;
                }
            }
            return rpta;
        }
    }
}


