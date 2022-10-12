using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.Features.Commands.Kullanici.UpdateKullanici;
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
            var user_exist = await _userManager.FindByEmailAsync(model.Email);
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
                UserName = model.Email
            }, model.Sifre);
            return result;
        }


        public async Task<IdentityResult> UpdateAsync(UpdateKullaniciQueryRequest model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            user.UserBio.Ad = model.Ad is null ? user.UserBio.Ad : model.Ad;
            user.UserBio.Soyad = model.Soyad is null ? user.UserBio.Soyad : model.Soyad;
            user.UserBio.Ulke = model.Ulke is null ? user.UserBio.Ulke : model.Ulke;
            user.UserBio.Sehir = model.Sehir is null ? user.UserBio.Sehir : model.Sehir;
            user.UserBio.AdresDetay = model.AdresDetay is null ? user.UserBio.AdresDetay : model.AdresDetay;
            IdentityResult result = await _userManager.UpdateAsync(user);

            await _userManager.UpdateSecurityStampAsync(user);
            return result;
        }
    }
}
