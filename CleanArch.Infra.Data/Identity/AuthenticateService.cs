using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager; 
        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
           var result= await _signInManager.PasswordSignInAsync(email, password,false,lockoutOnFailure:false);
            return result.Succeeded;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUserAsync(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName=email,
                Email=email
            };
            var result=await _userManager.CreateAsync(applicationUser,password);
            if(result.Succeeded)
                await _signInManager.SignInAsync(applicationUser, isPersistent:false);
            return result.Succeeded;
        }
    }
}
