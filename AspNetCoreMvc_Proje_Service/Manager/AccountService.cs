using AspNetCoreMvc_Proje_Entity.Entities.Identity.Models;
using AspNetCoreMvc_Proje_Entity.Services;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Service.Manager
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateUserAsync(RegisterViewModel model)
        {
            string message = string.Empty;
            var user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Username
            };

            var identityResult = await _userManager.CreateAsync(user, model.ConfirmPassword);

            if (identityResult.Succeeded)
            {
                message = "OK";
                
            }
            foreach (var error in identityResult.Errors)
            {
                message= error.Description;
            }
            return message;
        }

        public async Task<string> FinByNameAsync(LoginViewModel model)
        {
            string message = string.Empty;
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                message = "user not found";
                return message;
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);  
            if (signInResult.Succeeded)
            {
                message= "OK";

            }
            return message;
        }

        public async Task LogoutAsync()
        {
           await _signInManager.SignOutAsync();
        }
    }
}
