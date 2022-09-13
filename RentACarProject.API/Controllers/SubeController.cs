using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Domain.Entites;

namespace RentACarProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubeController : ControllerBase
    {
        private readonly ISubeReadAsyncRepository _subeReadAsyncRepository;
        private readonly ISubeReadRepository _subeReadRepository;
        private readonly ISubeWriteAsyncRepository _subeWriteAsyncRepository;
        private readonly ISubeWriteRepository _subeWriteRepository;

        public SubeController(ISubeReadAsyncRepository subeReadAsyncRepository, ISubeWriteAsyncRepository subeWriteAsyncRepository, ISubeWriteRepository subeWriteRepository, ISubeReadRepository subeReadRepository)
        {
            _subeReadAsyncRepository = subeReadAsyncRepository;
            _subeWriteAsyncRepository = subeWriteAsyncRepository;
            _subeWriteRepository = subeWriteRepository;
            _subeReadRepository = subeReadRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Sube sube)
        {
            await _subeWriteAsyncRepository.AddAsync(sube);
            await _subeWriteAsyncRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = _subeReadRepository.GetAll();
            return Ok(values);
        }

    }
}
