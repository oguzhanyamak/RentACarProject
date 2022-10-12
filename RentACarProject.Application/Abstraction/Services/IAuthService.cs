using RentACarProject.Application.ViewModel.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Abstraction.Services
{
    public interface IAuthService
    {
        Task<Application.ViewModel.Token.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
    }
}
