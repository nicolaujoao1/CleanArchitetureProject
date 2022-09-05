using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email,string password);
        Task<bool> RegisterUserAsync(string email,string password);
        Task Logout();
    }
}
