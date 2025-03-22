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
    public class EmpBasicInfoConfiguration : IEntityTypeConfiguration<EmpBasicInfo>
    {
        public void Configure(EntityTypeBuilder<EmpBasicInfo> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_EmpBasicInfo");

            builder.HasOne(d => d.AspNetUsers)
                .WithMany(p => p.EmpBasicInfo)
                .HasForeignKey(d => d.AspNetUserId)
                .HasConstraintName("FK_EmpBasicInfo_AspNetUsers");

            builder.HasOne(d => d.EmployeeType)
                .WithMany(p => p.EmpBasicInfo)
                .HasForeignKey(d => d.EmployeeTypeId)
                .HasConstraintName("FK_EmpBasicInfo_EmployeeType");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.EmpBasicInfo)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_EmpBasicInfo_Country");

            builder.HasOne(d => d.City)
                .WithMany(p => p.EmpBasicInfo)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_EmpBasicInfo_City");
        }
    }
}