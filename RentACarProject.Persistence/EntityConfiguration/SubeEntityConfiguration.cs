using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.EntityConfiguration
{
    public class SubeEntityConfiguration : BaseEntityConfiguration<Sube>
    {
        public override void Configure(EntityTypeBuilder<Sube> builder)
        {
            base.Configure(builder);
            
        }
    }
}
