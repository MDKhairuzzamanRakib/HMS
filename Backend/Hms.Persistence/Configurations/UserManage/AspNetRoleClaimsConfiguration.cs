using Hms.Domain.UserManage;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Persistence.Configurations.UserManage
{
    public class AspNetRoleClaimsConfiguration : IEntityTypeConfiguration<AspNetRoleClaims>
    {
        public void Configure(EntityTypeBuilder<AspNetRoleClaims> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_AspNetRoleClaims");
        }
    }
}
