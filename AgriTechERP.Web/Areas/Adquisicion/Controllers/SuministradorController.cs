using AgriTechERP.Core.Entidades;
using AgriTechERP.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgriTechERP.Web.Areas.Adquisicion.Controllers
{
    [Area("Adquisicion")]
    public class SuministradorController : Controller
    {
        
        // GET: SuministradorController

        private readonly ApplicationDbContext _context; 

        public SuministradorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: SuministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuministradorController/Create
        public async Task<IActionResult> Crear()
        {
            var listadoProductoSuministrador = await _context.ProductosSuministradores.ToListAsync();
            var productoSuministradorSelectListItem = new SelectList(listadoProductoSuministrador, "Id", "NombreProducto");
            
            return View(productoSuministradorSelectListItem);
        }

        // POST: SuministradorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SuministradorModel suministrador)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(suministrador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(suministrador);
        }

        // GET: SuministradorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuministradorController/Edit/5
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

        // GET: SuministradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuministradorController/Delete/5
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
