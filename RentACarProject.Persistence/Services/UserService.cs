using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.Features.Commands.Kullanici.KullaniciRole;
using RentACarProject.Application.Features.Commands.Kullanici.UpdateKullanici;
using RentACarProject.Application.ViewModel.Kullanici;
using RentACarProject.Application.ViewModel.Token;
using RentACarProject.Domain.Entites;
using RentACarProject.Domain.Entites.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RentACarProject.Persistence.Services
{
    public class UserService : IUserService
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly IMailService _mailService;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mailService = mailService;
        }

        public async Task<IdentityResult> AddRoleAsync(KullaniciRoleCommandRequest request)
        {
            AppRole role = await _roleManager.FindByIdAsync(request.RoleId);
            AppUser user = await _userManager.FindByIdAsync(request.KullaniciId);
            IdentityResult result = await _userManager.AddToRoleAsync(user,role.Name);
            return result;
        }

        public async Task<IdentityResult> ChangePassword(string email,string oldPassword,string newPassword)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            IdentityResult result = new();
            if (await _userManager.CheckPasswordAsync(user, oldPassword))
            {
                result = await _userManager.ChangePasswordAsync(user,oldPassword, newPassword);
                 
                await _userManager.UpdateSecurityStampAsync(user);
                return result;
            }
            return result;
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
            
            AppUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                UserBio = bio,
                UserName = model.Email,
                EmailConfirmed = false,
            };
            IdentityResult result = await _userManager.CreateAsync(user,model.Sifre);
            EmailVerification(user);
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

        public async void EmailVerification(AppUser user)
        {
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = HttpUtility.UrlEncode(code);
            string userId = HttpUtility.UrlEncode(user.Id);
            var emailBody = "Please Confirm your Email addres <a href=\"#url#\"> Click Hear ";
            //https://localhost:7155/Login
            var callBackUrl = $"https://localhost:7155/Authentication/VerifyEmail?userId={userId}&code={code}";

            var body = emailBody.Replace("#url#",callBackUrl);
            _mailService.sendEmail(user.Email, body);
        }

        public async Task<IdentityResult> verify(string id, string code)
        {
            id = HttpUtility.UrlDecode(id);
            var user = await _userManager.FindByIdAsync(id);
            code = HttpUtility.UrlDecode(code);
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return result;
        }
    }
}
