using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.ViewModel.Kullanici;
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
    }
}
