using AgriTechERP.Core.Entidades;
using AgriTechERP.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductoSuministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoSuministradorController/Create
        public ActionResult Crear()
        {
            return View();
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
