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
    public class RoomPricingConfiguration : IEntityTypeConfiguration<RoomPricing>
    {
        public void Configure(EntityTypeBuilder<RoomPricing> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_RoomPricing");

            builder.HasOne(d => d.RoomInfo)
                .WithMany(p => p.RoomPricing)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_RoomPricing_RoomInfo");

            builder.HasOne(d => d.RateType)
                .WithMany(p => p.RoomPricing)
                .HasForeignKey(d => d.RateTypeId)
                .HasConstraintName("FK_RoomPricing_RateType");
        }
    }
}