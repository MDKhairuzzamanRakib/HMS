using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.OrganogramSetup;

namespace Hms.Persistence.Configurations.OrganogramSetup
{
    public class DesignationSetupConfiguration : IEntityTypeConfiguration<DesignationSetup>
    {
        public void Configure(EntityTypeBuilder<DesignationSetup> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_DesignationSetup");
        }
    }
}