﻿using AgriTechERP.Core.Entidades.DTO;
using AgriTechERP.Core.Entidades.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "Cliente" });
        }

        // GET 

        [AllowAnonymous]
        public IActionResult IniciarSesion()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion(LoginDTO loginDTO)
        {

            if (ModelState.IsValid == false)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
                return View(loginDTO);
            }

           var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);
            
           if(result.Succeeded)
           {
                return RedirectToAction("Index");
           }
           
           ModelState.AddModelError("IniciarSesion", "Invalid email or password");     
          
           return View(loginDTO);
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
