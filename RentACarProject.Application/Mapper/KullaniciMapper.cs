using AutoMapper;
using RentACarProject.Application.Features.Commands.Kullanici.CreateKullanici;
using RentACarProject.Application.Features.Commands.Kullanici.KullaniciRole;
using RentACarProject.Application.Features.Commands.Kullanici.UpdateKullanici;
using RentACarProject.Application.ViewModel.Kullanici;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Mapper
{
    public class KullaniciMapper : Profile
    {
        public KullaniciMapper()
        {
            CreateMap<KullaniciEkleVM, CreateKullaniciCommandRequest>().ReverseMap();
            CreateMap<CreateKullaniciCommandRequest, AppUser>().ReverseMap();

            CreateMap<KullaniciGuncelleVM, UpdateKullaniciQueryRequest>().ReverseMap();

            CreateMap<KullaniciRoleVM, KullaniciRoleCommandRequest>().ReverseMap();
        }
    }
}
