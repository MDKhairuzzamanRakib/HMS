using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.UserManage;

namespace Hms.Persistence.Configurations.UserManage
{
    public class AspNetUserRolesConfiguration : IEntityTypeConfiguration<AspNetUserRoles>
    {
        public void Configure(EntityTypeBuilder<AspNetUserRoles> builder)
        {
            builder.HasKey(e => new { e.UserId, e.RoleId })
                .HasName("PK_AspNetUserRoles");

            builder.HasOne(d => d.AspNetUsers)
                .WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserRoles_AspNetUsers");

            builder.HasOne(d => d.AspNetRoles)
                .WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetUserRoles_AspNetRoles");
        }
    }
}