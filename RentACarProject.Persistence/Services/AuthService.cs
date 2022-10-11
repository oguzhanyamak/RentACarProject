using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.ViewModel.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Services
{
    public class AuthService : IAuthService
    {
        public Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }
    }
}
