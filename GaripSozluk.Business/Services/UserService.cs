using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using GaripSozluk.Data.Domain;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace GaripSozluk.Business.Services
{
  public  class UserService:IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<Role> _roleManager;
        public UserService(Microsoft.AspNetCore.Identity.UserManager<User> userManager, SignInManager<User> signInManager, Microsoft.AspNetCore.Identity.RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public bool Register(RegisterVM model)
        {
            var newUser = new User();
            newUser.UserName = model.Username;
            newUser.Email = model.MailAddress;

            var result = _userManager.CreateAsync(newUser, model.Password).Result;
            if (result.Succeeded)
            {
                var roles = _roleManager.Roles;
                var addRoleResult = _userManager.AddToRoleAsync(newUser, "User").Result;
                if (addRoleResult.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false; 
        }

        public bool Login(LoginVM model)
        {
            var result = _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false).Result;
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public User GetUser(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }


    }
}
