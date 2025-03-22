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
    public class RateTypeConfiguration : IEntityTypeConfiguration<RateType>
    {
        public void Configure(EntityTypeBuilder<RateType> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("PK_RateType");
        }
    }
}
