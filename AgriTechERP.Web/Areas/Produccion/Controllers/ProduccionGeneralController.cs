using AgriTechERP.Core.Entidades;
using AgriTechERP.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace AgriTechERP.Web.Areas.Produccion.Controllers
{
    [Area("Produccion")]
        public class ProduccionGeneralController : Controller
        {
            private readonly ApplicationDbContext _context;

            public ProduccionGeneralController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Produccion/Index
            public async Task<IActionResult> Index()
            {
                var producciones = await _context.ProductosProduccion
                    .Include(p => p.Ingredientes) // Cargar los ingredientes
                    .ToListAsync();

                return View(producciones);
            }

            // GET: Produccion/Crear
            public async Task<IActionResult> Crear()
            {
                var productosSuministradores = await _context.ProductosSuministradores.ToListAsync();
                ViewBag.ProductosSuministradores = productosSuministradores;
                return View(new ProduccionModel());
            }

            // POST: Produccion/Crear
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Crear(ProduccionModel produccionModel, int[] ingredientesIds)
            {
                if (ModelState.IsValid)
                {
                    foreach (var ingredienteId in ingredientesIds)
                    {
                        var productoSuministrador = await _context.ProductosSuministradores.FindAsync(ingredienteId);
                        if (productoSuministrador != null)
                        {
                            produccionModel.Ingredientes.Add(productoSuministrador);
                        }
                    }

                    _context.ProductosProduccion.Add(produccionModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.ProductosSuministradores = await _context.ProductosSuministradores.ToListAsync();
                return View(produccionModel);
            }
        }
    }



