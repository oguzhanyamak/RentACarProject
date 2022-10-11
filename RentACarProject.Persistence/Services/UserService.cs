using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.ViewModel.Kullanici;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Services
{
    public class UserService : IUserService
    {
        UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(KullaniciEkleVM model)
        {

            UserBio bio = new()
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                Sehir = model.Sehir,
                TC = model.TC,
                Ulke = model.Ulke,
                Cadde = model.Cadde,
                AdresDetay = model.AdresDetay
            };

            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                UserBio = bio,
                UserName =  model.Email
            }, model.Sifre);
            return result;

        }
    }
}
