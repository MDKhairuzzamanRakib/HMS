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
        }
    }
}