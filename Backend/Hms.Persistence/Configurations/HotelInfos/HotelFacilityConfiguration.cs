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
    public class HotelFacilityConfiguration : IEntityTypeConfiguration<HotelFacility>
    {
        public void Configure(EntityTypeBuilder<HotelFacility> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_HotelFacility");

            builder.HasOne(d => d.HotelInfo)
                .WithMany(p => p.HotelFacility)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK_HotelFacility_HotelInfo");
        }
    }
}