using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020GG602_2020SM602_2020ML601.Models;

namespace P2_2020GG602_2020SM602_2020ML601.Controllers
{
    public class registroController : Controller
    {
        private readonly hospitalDbContext _hospitalDbContext;
        public registroController(hospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }
        public IActionResult Index()
        {
            var listaDepartamentos = (from m in _hospitalDbContext.departamento
                                      select m).ToList();
            ViewData["listaDepartamentos"] = new SelectList(listaDepartamentos, "iddepartamento", "nombredepartamento");

            var listaGeneros = (from m in _hospitalDbContext.generos
                                select m).ToList();
            ViewData["listaGeneros"] = new SelectList(listaGeneros, "idgenero", "generotipo");

            var listadoRegistro = (from e in _hospitalDbContext.departamento
                                   join m in _hospitalDbContext.casosreportados on e.iddepartamento equals m.iddepartamento
                                   join f in _hospitalDbContext.generos on m.idgenero equals f.idgenero
                                   select new
                                   {
                                       Departamento = e.nombredepartamento,
                                       Genero = f.generotipo,
                                       Confirmados = m.confirmados,
                                       Recuperados = m.recuperados,
                                       Fallecidos = m.fallecidos,
                                   }).ToList();
            ViewData["listadodeRegistros"] = listadoRegistro;

            return View();
        }
        public IActionResult CrearRegistro(casosreportados nuevoCasos)
        {
            _hospitalDbContext.Add(nuevoCasos);
            _hospitalDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
