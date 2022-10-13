using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;


        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, HttpClient httpClient, IConfiguration configuration, ILogger logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _logger = logger;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            _logger.LogInformation("sa");
            AppUser user = await _userManager.FindByEmailAsync(usernameOrEmail);
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            Token token = new();
            //...Authorize
            if (result.Succeeded) //Authentication başarılı!
            {
                token = await _tokenHandler.CreateAccessToken(user);
                return token;
            }
            return token;
        }
    }
}
