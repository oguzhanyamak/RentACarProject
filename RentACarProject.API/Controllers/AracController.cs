using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Application.ViewModel;
using RentACarProject.Domain.Entites;

namespace RentACarProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AracController : ControllerBase
    {

        private readonly IAracWriteAsyncRepository _aracWriteAsyncRepository;
        private readonly ISubeReadAsyncRepository _subeReadAsyncRepository;

        public AracController(IAracWriteAsyncRepository aracWriteAsyncRepository, ISubeReadAsyncRepository subeReadAsyncRepository)
        {
            _aracWriteAsyncRepository = aracWriteAsyncRepository;
            _subeReadAsyncRepository = subeReadAsyncRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AracEkleVM parac)
        {
            Arac arac = new Arac()
            {
                Id = Guid.NewGuid(),
                BeygirGucu = parac.BeygirGucu,
                Durum = parac.Durum,
                Marka = parac.Marka,
                Plaka = parac.Plaka,
                Model = parac.Model,
                MotorHacmi = parac.MotorHacmi,
                SaatUcreti = parac.SaatUcreti,
                VitesTuru = parac.VitesTuru
            };

            Sube sube = await _subeReadAsyncRepository.GetSingleAsync(i => i.Id == parac.SubeId);
            arac.Sube = sube;

            await _aracWriteAsyncRepository.AddAsync(arac);
            await _aracWriteAsyncRepository.SaveAsync();
            return Ok();
        }
    }
}
