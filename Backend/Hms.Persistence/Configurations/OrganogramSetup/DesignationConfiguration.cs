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
    public class DesignationConfiguration : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_Designation");

            builder.HasOne(d => d.HotelInfo)
                .WithMany(p => p.Designation)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK_Designation_HotelInfo");

            builder.HasOne(d => d.Department)
                .WithMany(p => p.Designation)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Designation_Department");

            builder.HasOne(d => d.Section)
                .WithMany(p => p.Designation)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_Designation_Section");

            builder.HasOne(d => d.DesignationSetup)
                .WithMany(p => p.Designation)
                .HasForeignKey(d => d.DesignationSetupId)
                .HasConstraintName("FK_Designation_DesignationSetup");
        }
    }
}