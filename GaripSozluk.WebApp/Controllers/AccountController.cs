using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace GaripSozluk.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        
 
        private readonly IUserService _userService;
        //  private readonly IRoleService _roleService;

        private readonly SignInManager<User> _signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<Role> _roleManager;


        public AccountController(ILogger<AccountController> logger,
            Microsoft.AspNetCore.Identity.UserManager<User> userManager, SignInManager<User> signInManager, Microsoft.AspNetCore.Identity.RoleManager<Role> roleManager, IUserService UserService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = UserService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Login(model))
                {
                    //return Redirect(this.Action<HomeController>(nameof(Index)));

                    return Redirect(Url.Action("index", "home"));
                }

            }
         
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM registerModel)
        {
            if (ModelState.IsValid)
            {
                if (registerModel.Password == registerModel.ConfirmPassword)
                {
                    if (_userService.Register(registerModel))
                    {
                        return Redirect(Url.Action("index", "home"));
                    }
                    ModelState.AddModelError("", $"Geçmiş olsun yemezler!!!");
                }
            }
            return View(registerModel);
        }

        private string Action<T>(string v)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Register2(RegisterVM model)
        {
            if (ModelState.IsValid)
            {

                return Redirect(Url.Action("Login", "Administration"));
            }

            return View(model);
        }

        [Authorize]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync().Wait();
            return Redirect(Url.Action("Account", "Login"));
        }

    }
}
