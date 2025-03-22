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
    public class EmpPersonalInfoConfiguration : IEntityTypeConfiguration<EmpPersonalInfo>
    {
        public void Configure(EntityTypeBuilder<EmpPersonalInfo> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_EmpPersonalInfo");

            builder.HasOne(d => d.EmpBasicInfo)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpPersonalInfo_EmpBasicInfo");

            builder.HasOne(d => d.Gender)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_EmpPersonalInfo_Gender");

            builder.HasOne(d => d.MaritalStatus)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.MaritalStatusId)
                .HasConstraintName("FK_EmpPersonalInfo_MaritalStatus");

            builder.HasOne(d => d.BloodGroup)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.BloodGroupId)
                .HasConstraintName("FK_EmpPersonalInfo_BloodGroup");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK_EmpPersonalInfo_EmpBasicInfo");

            builder.HasOne(d => d.EmpBasicInfo)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpPersonalInfo_EmpBasicInfo");

            builder.HasOne(d => d.EmpBasicInfo)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpPersonalInfo_EmpBasicInfo");

            builder.HasOne(d => d.EmpBasicInfo)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpPersonalInfo_EmpBasicInfo");

            builder.HasOne(d => d.EmpBasicInfo)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpPersonalInfo_EmpBasicInfo");

            builder.HasOne(d => d.EmpBasicInfo)
                .WithMany(p => p.EmpPersonalInfo)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpPersonalInfo_EmpBasicInfo");
        }
    }
}