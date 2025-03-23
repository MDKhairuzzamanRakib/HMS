using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.BookingInfos;

namespace Hms.Persistence.Configurations.BookingInfos
{
    public class BookingInfoConfiguration : IEntityTypeConfiguration<BookingInfo>
    {
        public void Configure(EntityTypeBuilder<BookingInfo> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_BookingInfo");

            builder.HasOne(d => d.GuestInfo)
                .WithMany(p => p.BookingInfo)
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("FK_BookingInfo_GuestInfo");

            builder.HasOne(d => d.RoomPricing)
                .WithMany(p => p.BookingInfo)
                .HasForeignKey(d => d.RoomPricingId)
                .HasConstraintName("FK_BookingInfo_RoomPricing");

            builder.HasOne(d => d.ReferedBy)
                .WithMany(p => p.BookingInfoReferBy)
                .HasForeignKey(d => d.ReferedById)
                .HasConstraintName("FK_BookingInfo_ReferedBy");

            builder.HasOne(d => d.DiscountBy)
                .WithMany(p => p.BookingInfoDiscountBy)
                .HasForeignKey(d => d.DiscountById)
                .HasConstraintName("FK_BookingInfo_DiscountBy");
        }
    }
}