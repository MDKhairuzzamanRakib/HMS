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
    public class AspNetRolesConfiguration : IEntityTypeConfiguration<AspNetRoles>
    {
        public void Configure(EntityTypeBuilder<AspNetRoles> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_AspNetRoles");

            builder.HasData(
                new AspNetRoles
                {
                    Id = "b9dfc798-d2cf-4010-9f8b-2068a91bdfaf",
                    Name = "Guest",
                },
                new AspNetRoles
                {
                    Id = "8692fe73-efe2-4fd2-94be-4545f88be14d",
                    Name = "User",
                },
                new AspNetRoles
                {
                    Id = "a7a25bd6-da61-43c8-93db-ba4d08642ad9",
                    Name = "Admin",
                }
            );
        }
    }
}
