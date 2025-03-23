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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_Department");

            builder.HasOne(d => d.HotelInfos)
                .WithMany(p => p.Department)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK_Department_Country");
        }
    }
}
