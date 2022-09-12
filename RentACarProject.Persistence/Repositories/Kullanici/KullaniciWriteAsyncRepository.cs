﻿using RentACarProject.Application.Repositories.Kullanici;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Kullanici
{
    public class KullaniciWriteAsyncRepository : WriteAsyncRepository<Domain.Entites.Kullanici>, IKullaniciWriteAsyncRepository
    {
        public KullaniciWriteAsyncRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
