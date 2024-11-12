using AgriTechERP.Core.Entidades;
using AgriTechERP.Infrastructure.Data;
using AgriTechERP.Web.Views.ViewModels.ListadoViewModels;
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

        public async Task<IActionResult> Index()
        {
            var suministradores = await _context.Suministradores.ToListAsync();

            var viewModel = new ListadoSuministradorViewModel
            {
                Suministradores = suministradores
            };
            return View(viewModel);
        }

        // GET: SuministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuministradorController/Create
        public IActionResult Crear()
        {

            return View();
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
