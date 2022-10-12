using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.Features.Commands.Role.UpdateRole;
using RentACarProject.Application.ViewModel.Role;
using RentACarProject.Domain.Entites.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(string RoleName)
        {
            IdentityResult result = await _roleManager.CreateAsync(new AppRole() { Id = Guid.NewGuid().ToString(), Name = RoleName });
            return result;
        }

        public List<AppRole> GetAllRoles()
        {
            List<AppRole> roles = _roleManager.Roles.ToList();
            return roles;

        }

        public async Task<IdentityResult> UpdateRoleAsync(UpdateRoleCommandRequest request)
        {
            IdentityResult result = null;
            AppRole role = await _roleManager.FindByIdAsync(request.RoleId);
            role.Name = request.NewName;
            result = await _roleManager.UpdateAsync(role);
            return result;
        }
    }
}
