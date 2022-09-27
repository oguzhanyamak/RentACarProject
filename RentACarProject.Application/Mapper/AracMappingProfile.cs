using AutoMapper;
using RentACarProject.Application.Features.Commands.Arac.CreateArac;
using RentACarProject.Application.Features.Commands.Arac.UpdateArac;
using RentACarProject.Application.ViewModel.Arac;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Mapper
{
    public class AracMappingProfile : Profile
    {
        public AracMappingProfile()
        {
            CreateMap<AracEkleVM, CreateAracCommandRequest>().ReverseMap();
            CreateMap<CreateAracCommandRequest,Arac>().ReverseMap();

            CreateMap<AracGuncelleVM, UpdateAracCommandRequest>().ReverseMap();
        }
    }
}
