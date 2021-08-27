using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Week5.Test.Core.Interfaces;
using Week5.Test.Core.Models;
using Week5.Test.MVC.Models;

namespace Week5.Test.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IBusinessLayer bl;

        public UserController(IBusinessLayer businessLayer)
        {
            bl = businessLayer;
        }

        //registrazione utente
        [Authorize(Policy = "UserCliente")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy ="UserCliente")]
        public IActionResult Create(UserViewModel newUser)
        {
            if (newUser == null)
                return View("Error", new ErrorViewModel());
            var result = bl.Create(new User()
            {
                Password = newUser.Password,
                Username = newUser.Username,
                Ruolo = Ruolo.Cliente
            });
            if (result)
                return RedirectToAction("Index");
            return View();
        }

        #region Login
        public IActionResult Login(string returnUrl)
        {
            return View(new UserViewModel
            {
                ReturnURL = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel viewModel)
        {
            if (viewModel == null)
                return View("Error", new ErrorViewModel());
            var user = bl.GetUserByUsername(viewModel.Username);
            if (user == null || !ModelState.IsValid)
                return View(viewModel);
            if (user.Password.Equals(viewModel.Password))
            {
                //1. claim
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, viewModel.Username),
                    new Claim(ClaimTypes.Role, user.Ruolo.ToString())
                };
                //2. proprietà di autenticazione
                var authProperty = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.Now.AddMinutes(30),
                    RedirectUri = viewModel.ReturnURL
                };
                //3. claim nei cookie di autenticazione
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //4. SignIn
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperty);
                //5. ritorno alla home
                return Redirect("/");

            }
            else //utente ha sbagliato password
            {
                ModelState.AddModelError(nameof(viewModel.Password), "Password not correct");
                return View(viewModel);
            }


        }

        #endregion

        #region Forbidden & Logout

        public IActionResult Forbidden()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        #endregion
    }
}
