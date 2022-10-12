using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Auth;
using RentACarProject.Application.ViewModel.Auth;

namespace RentACarProject.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public AuthController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [Route("/Login")]
        [HttpPost]
        public async Task<IActionResult> login(LoginVM login)
        {
            AuthCommandRequest request = new() { Email = login.Email, Password = login.Password };
            AuthCommandResponse response = await _mediatR.Send(request);
            return Ok(response);
        }

    }
}
