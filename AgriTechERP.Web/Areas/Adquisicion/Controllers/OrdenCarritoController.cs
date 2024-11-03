using AgriTechERP.Core.Entidades;
using AgriTechERP.Infrastructure.Data;
using AgriTechERP.Web.Views.ViewModels.ListadoViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriTechERP.Web.Areas.Adquisicion.Controllers
{
    [Area("Adquisicion")]
    public class OrdenCarritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenCarritoController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: OrdenCarritoController
        public async Task<IActionResult> Index()
        {
            var ordenes = await _context.OrdenCarritos.Include(p => p.ProductoSuministrador).ToListAsync();

            var viewModel = new ListadoOrdenCarritoViewModel
            {
                listadoOrdenCarrito = ordenes
            };
            return View(viewModel);
        }

        // GET: OrdenCarritoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Ordenar(int productoId)
        {
            var producto = await _context.ProductosSuministradores.FindAsync(productoId);

            if(producto == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.OrdenCarritos.SingleOrDefaultAsync(c => c.ProductoSuministradorId == productoId);

            if (carritoItem != null && carritoItem.ProductoSuministrador != null)
            {
                var cantidad = ++carritoItem.Cantidad;
                // Cantidad ++ 
            }
            else
            {
                carritoItem = new OrdenCarritoModel()
                {
                    ProductoSuministradorId = productoId, 
                    Aprobacion = 0, 
                    Cantidad = 1
                    // Más propiedades
                };

                await _context.OrdenCarritos.AddAsync(carritoItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");   

           
        }

        // GET: OrdenCarritoController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: OrdenCarritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenCarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenCarritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenCarritoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenCarritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
