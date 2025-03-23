using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Persistence.Configurations.BasicSetup
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_City");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.City)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_City_Country");
        }
    }
}