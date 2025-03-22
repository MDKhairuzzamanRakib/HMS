using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.EmployeeInfos;

namespace Hms.Persistence.Configurations.EmployeeInfos
{
    public class EmpJobDetailsConfiguration : IEntityTypeConfiguration<EmpJobDetail>
    {
        public void Configure(EntityTypeBuilder<EmpJobDetail> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_EmpJobDetail");

            builder.HasOne(d => d.EmpBasicInfo)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpJobDetail_EmpBasicInfo");

            builder.HasOne(d => d.HotelInfo)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.FirstHotelId)
                .HasConstraintName("FK_EmpJobDetail_HotelInfo");

            builder.HasOne(d => d.Department)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_EmpJobDetail_Department");

            builder.HasOne(d => d.Section)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_EmpJobDetail_Section");

            builder.HasOne(d => d.Designation)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK_EmpJobDetail_Designation");

            builder.HasOne(d => d.FirstHotelInfo)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.FirstHotelId)
                .HasConstraintName("FK_EmpJobDetail_FirstHotelInfo");

            builder.HasOne(d => d.FirstDepartment)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.FirstDepartmentId)
                .HasConstraintName("FK_EmpJobDetail_FirstDepartment");

            builder.HasOne(d => d.FirstSection)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.FirstSection)
                .HasConstraintName("FK_EmpJobDetail_FirstSection");

            builder.HasOne(d => d.FirstDesignation)
                .WithMany(p => p.EmpJobDetail)
                .HasForeignKey(d => d.FirstDesignationId)
                .HasConstraintName("FK_EmpJobDetail_FirstDesignation");
        }
    }
}