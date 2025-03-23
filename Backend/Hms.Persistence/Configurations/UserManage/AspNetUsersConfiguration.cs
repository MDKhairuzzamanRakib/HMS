using Hms.Domain.UserManage;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hms.Persistence.Configurations.UserManage
{
    public class AspNetUsersConfiguration : IEntityTypeConfiguration<AspNetUsers>
    {
        public void Configure(EntityTypeBuilder<AspNetUsers> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_AspNetUsers");

            builder.HasOne(d => d.UserType)
                .WithMany(p => p.AspNetUsers)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK_AspNetUsers_UserType");

            var hasher = new PasswordHasher<AspNetUsers>();
            builder.HasData(
                 new AspNetUsers
                 {
                     Id = "0ad790b9-331b-47a0-b707-8bbb6e2ef1dd",
                     Email = "guest@localhost.com",
                     NormalizedEmail = "GUEST@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "Guest",
                     UserName = "guest",
                     NormalizedUserName = "GUEST",
                     PasswordHash = hasher.HashPassword(null, "Guest@123"),
                     EmailConfirmed = true
                 },
                 new AspNetUsers
                 {
                     Id = "15b95c84-5f38-4318-a5c1-114e4d459980",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user",
                     NormalizedUserName = "USER",
                     PasswordHash = hasher.HashPassword(null, "User@123"),
                     EmailConfirmed = true
                 },
                 new AspNetUsers
                 {
                     Id = "1f2f4587-b2f3-4421-984d-0a576465c1c7",
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "admin",
                     NormalizedUserName = "ADMIN",
                     PasswordHash = hasher.HashPassword(null, "Admin@123"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}