using AgriTechERP.Core.Entidades;
using AgriTechERP.Infrastructure.Data;
using AgriTechERP.Web.Views.ViewModels.ListadoViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgriTechERP.Web.Areas.Adquisicion.Controllers
{
    [Area("Adquisicion")]
    public class ProductoSuministradorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoSuministradorController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProductoSuministradorController
        public async Task<IActionResult> Index()
        {
            var productoSuministrador = await _context.ProductosSuministradores.Include(s => s.Suministrador).ToListAsync();

            var listadoViewModel = new ListadoProductoSuministradorViewModel
            {
                productosSuministradores = productoSuministrador,
            };
            return View(listadoViewModel);
        }

        // GET: ProductoSuministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoSuministradorController/Create
        public async Task<IActionResult> Crear()
        {
            var listadoSuministrador = await _context.Suministradores.ToListAsync();
            ViewBag.SuministradorSelectList = new SelectList(listadoSuministrador, "Id", "RazonSocial");
            var model = new ProductoSuministradorModel();
            return View(model);
        }

        // POST: ProductoSuministradorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ProductoSuministradorModel producto)
        {
            if (ModelState.IsValid)
            {
                await _context.ProductosSuministradores.AddAsync(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: ProductoSuministradorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoSuministradorController/Edit/5
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

        // GET: ProductoSuministradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoSuministradorController/Delete/5
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
