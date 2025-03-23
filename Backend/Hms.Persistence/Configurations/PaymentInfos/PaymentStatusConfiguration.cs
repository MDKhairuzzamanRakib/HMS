using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.PaymentInfos;

namespace Hms.Persistence.Configurations.PaymentInfos
{
    public class PaymentStatusConfiguration : IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_PaymentStatus");

            builder.HasOne(d => d.PaymentType)
                .WithMany(p => p.PaymentStatus)
                .HasForeignKey(d => d.PaymentTypeId)
                .HasConstraintName("FK_PaymentStatus_PaymentType");

            builder.HasOne(d => d.BookingInfo)
                .WithMany(p => p.PaymentStatus)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK_PaymentStatus_BookingInfo");

            builder.HasOne(d => d.EmpBasicInfo)
                .WithMany(p => p.PaymentStatus)
                .HasForeignKey(d => d.ConfirmedBy)
                .HasConstraintName("FK_PaymentStatus_EmpBasicInfo");
        }
    }
}
