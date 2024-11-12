using AgriTechERP.Core.Entidades.DTO;
using AgriTechERP.Core.Entidades.IdentityEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriTechERP.Web.Areas.Registrar.Controllers
{
    [Area("Registrar")]
    public class CuentaController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public CuentaController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: CuentaController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarDTO registrarDTO)
        {
            // Comprobar si hay validation errors
            if (ModelState.IsValid == false)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
                return View(registrarDTO);
            }

            // Inicializar lo que hemos creado en ApplicationUser DTO excepto en las contraseñas

            ApplicationUser user = new ApplicationUser()
            {
                Email = registrarDTO.Email,
                PhoneNumber = registrarDTO.Phone,
                UserName = registrarDTO.Email,
                NombreCompleto = registrarDTO.PersonName, 
               
            };


            // IdentityResult si exitoso o no
            IdentityResult result = await _userManager.CreateAsync(user, registrarDTO.Password);
            
            if (result.Succeeded)
            {
                // SIGN IN 
                await _signInManager.SignInAsync(user, isPersistent : false); // keep me logged in feature...


                return RedirectToAction("Index");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Registrar", error.Description);
                }
            }
            
            return View(registrarDTO);
        }
        // GET: CuentaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CuentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CuentaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CuentaController/Edit/5
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

        // GET: CuentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CuentaController/Delete/5
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
