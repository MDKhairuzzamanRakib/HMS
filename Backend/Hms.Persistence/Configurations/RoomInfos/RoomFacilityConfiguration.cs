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
    public class RoomFacilityConfiguration : IEntityTypeConfiguration<RoomFacility>
    {
        public void Configure(EntityTypeBuilder<RoomFacility> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_RoomFacility");

            builder.HasOne(d => d.RoomInfo)
                .WithMany(p => p.RoomFacility)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_RoomFacility_Country");
        }
    }
}
