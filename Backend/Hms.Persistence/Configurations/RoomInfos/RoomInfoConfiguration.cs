using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.RoomInfos;

namespace Hms.Persistence.Configurations.RoomInfos
{
    public class RoomInfoConfiguration : IEntityTypeConfiguration<RoomInfo>
    {
        public void Configure(EntityTypeBuilder<RoomInfo> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_RoomInfo");

            builder.HasOne(d => d.HotelInfo)
                .WithMany(p => p.RoomInfo)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK_RoomInfo_HotelInfo");

            builder.HasOne(d => d.RoomType)
                .WithMany(p => p.RoomInfo)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK_RoomInfo_RoomType");
        }
    }
}
