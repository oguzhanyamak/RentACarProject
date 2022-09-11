using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.EntityConfiguration
{
    public class SiparisEntityConfiguration :BaseEntityConfiguration<Siparis>
    {
        public override void Configure(EntityTypeBuilder<Siparis> builder)
        {
            base.Configure(builder);
            builder.HasOne(i => i.Sube).WithMany(i => i.Siparisler).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
