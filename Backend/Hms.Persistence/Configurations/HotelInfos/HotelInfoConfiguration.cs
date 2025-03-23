using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.HotelInfos;

namespace Hms.Persistence.Configurations.HotelInfos
{
    public class HotelInfoConfiguration : IEntityTypeConfiguration<HotelInfo>
    {
        public void Configure(EntityTypeBuilder<HotelInfo> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_HotelInfo");

            builder.HasOne(d => d.CategoryType)
                .WithMany(p => p.HotelInfo)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_HotelInfo_CategoryType");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.HotelInfo)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_HotelInfo_Country");

            builder.HasOne(d => d.City)
                .WithMany(p => p.HotelInfo)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_HotelInfo_City");
        }
    }
}
