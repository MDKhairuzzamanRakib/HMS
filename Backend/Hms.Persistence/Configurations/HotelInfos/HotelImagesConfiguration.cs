using Hms.Domain.HotelInfos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Persistence.Configurations.HotelInfos
{
    public class HotelImagesConfiguration : IEntityTypeConfiguration<HotelImages>
    {
        public void Configure(EntityTypeBuilder<HotelImages> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_HotelImages");

            builder.HasOne(d => d.HotelInfo)
                .WithMany(p => p.HotelImages)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK_HotelImages_HotelInfo");
        }
    }
}