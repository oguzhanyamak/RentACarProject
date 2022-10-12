using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.Abstraction.Token;
using RentACarProject.Application.ViewModel.Token;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;


        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, HttpClient httpClient, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByEmailAsync(usernameOrEmail);
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            //...Authorize
            Token token = _tokenHandler.CreateAccessToken(user);
            return token;
        }
    }
}
