using AutoMapper;
using RentACarProject.Application.Features.Commands.Sube.CreateSube;
using RentACarProject.Application.Features.Commands.Sube.UpdateSube;
using RentACarProject.Application.Features.Queries.Sube.GetById;
using RentACarProject.Application.ViewModel.Sube;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Mapper
{
    public class SubeMappingProfile : Profile
    {
        public SubeMappingProfile()
        {
            CreateMap<SubeEkleVM, CreateSubeCommandRequest>().ReverseMap();
            CreateMap<CreateSubeCommandRequest, Sube>()
                .ForMember(i => i.SubeAdi, o => o.MapFrom(s => s.SubeAdi))
                .ForMember(i => i.Sehir, o => o.MapFrom(s => s.Sehir))
                .ForMember(i => i.Ulke, o => o.MapFrom(s => s.Ulke))
                .ForMember(i => i.Cadde, o => o.MapFrom(s => s.Cadde))
                .ForMember(i => i.AdresDetay, o => o.MapFrom(s => s.Detay)).ReverseMap();

            CreateMap<SubeGuncelleVM, UpdateSubeCommandRequest>().ReverseMap();
            CreateMap<UpdateSubeCommandRequest, Sube>();
        }
    }
}
