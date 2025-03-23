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
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_Section");

            builder.HasOne(d => d.HotelInfo)
                .WithMany(p => p.Section)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK_Section_HotelInfo");

            builder.HasOne(d => d.Department)
                .WithMany(p => p.Section)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Section_Department");
        }
    }
}
