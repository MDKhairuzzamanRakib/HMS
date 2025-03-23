using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Persistence.Configurations.BasicSetup
{
    public class HairColorConfiguration : IEntityTypeConfiguration<HairColor>
    {
        public void Configure(EntityTypeBuilder<HairColor> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("PK_HairColor");
        }
    }
}
