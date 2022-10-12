using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Features.Commands.Role.UpdateRole;
using RentACarProject.Application.ViewModel.Kullanici;
using RentACarProject.Domain.Entites.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Abstraction.Services
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRoleAsync(string RoleName);
        Task<IdentityResult> UpdateRoleAsync(UpdateRoleCommandRequest request);
        List<AppRole> GetAllRoles();
    }
}
