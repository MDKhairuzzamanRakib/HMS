using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.GuestInfos;

namespace Hms.Persistence.Configurations.GuestInfos
{
    public class GuestInfoConfiguration : IEntityTypeConfiguration<GuestInfo>
    {
        public void Configure(EntityTypeBuilder<GuestInfo> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_GuestInfo");

            builder.HasOne(d => d.AspNetUsers)
                .WithMany(p => p.GuestInfo)
                .HasForeignKey(d => d.AspNetUserId)
                .HasConstraintName("FK_GuestInfo_AspNetUsers");

            builder.HasOne(d => d.Gender)
                .WithMany(p => p.GuestInfo)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_GuestInfo_Gender");

            builder.HasOne(d => d.MaritalStatus)
                .WithMany(p => p.GuestInfo)
                .HasForeignKey(d => d.MaritalStatusId)
                .HasConstraintName("FK_GuestInfo_MaritalStatus");

            builder.HasOne(d => d.BloodGroup)
                .WithMany(p => p.GuestInfo)
                .HasForeignKey(d => d.BloodGroupId)
                .HasConstraintName("FK_GuestInfo_BloodGroup");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.GuestInfo)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_GuestInfo_Country");

            builder.HasOne(d => d.City)
                .WithMany(p => p.GuestInfo)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_GuestInfo_City");

            builder.HasOne(d => d.Religion)
                .WithMany(p => p.GuestInfo)
                .HasForeignKey(d => d.ReligionId)
                .HasConstraintName("FK_GuestInfo_Religion");
        }
    }
}