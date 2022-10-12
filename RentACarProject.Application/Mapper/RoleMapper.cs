﻿using AutoMapper;
using RentACarProject.Application.Features.Commands.Role.UpdateRole;
using RentACarProject.Application.Features.Commands.Siparis.Create;
using RentACarProject.Application.ViewModel.Role;
using RentACarProject.Application.ViewModel.Siparis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Mapper
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<RoleUpdateVM,UpdateRoleCommandRequest>().ReverseMap();
        }
    }
}
