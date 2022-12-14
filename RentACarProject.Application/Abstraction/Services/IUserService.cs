using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Features.Commands.Kullanici.KullaniciRole;
using RentACarProject.Application.Features.Commands.Kullanici.UpdateKullanici;
using RentACarProject.Application.ViewModel.Kullanici;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Abstraction.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(KullaniciEkleVM model);
        Task<IdentityResult> UpdateAsync(UpdateKullaniciQueryRequest model);
        Task<IdentityResult> ChangePassword(string email,string oldPassword,string newPassword);
        Task<IdentityResult> AddRoleAsync(KullaniciRoleCommandRequest request);
        void EmailVerification(AppUser user);
        Task<IdentityResult> verify(string id,string code);
    }
}
