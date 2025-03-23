using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.UserManage;
using Microsoft.AspNetCore.Identity;

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

            builder.HasData(
                new AspNetUserRoles
                {
                    RoleId = "b9dfc798-d2cf-4010-9f8b-2068a91bdfaf",
                    UserId = "0ad790b9-331b-47a0-b707-8bbb6e2ef1dd"
                },
                new AspNetUserRoles
                {
                    RoleId = "8692fe73-efe2-4fd2-94be-4545f88be14d",
                    UserId = "15b95c84-5f38-4318-a5c1-114e4d459980"
                },
                new AspNetUserRoles
                {
                    RoleId = "a7a25bd6-da61-43c8-93db-ba4d08642ad9",
                    UserId = "1f2f4587-b2f3-4421-984d-0a576465c1c7"
                }
            );
        }
    }
}