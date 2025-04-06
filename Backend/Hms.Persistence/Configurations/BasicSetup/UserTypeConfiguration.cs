using Hms.Domain.BasicSetup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Domain.UserManage;

namespace Hms.Persistence.Configurations.BasicSetup
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("PK_UserType");

            builder.HasData(
                new UserType
                {
                    TypeName = "Guest",
                    Position = 1,
                    Status = true,
                },
                new UserType
                {
                    TypeName = "Staff",
                    Position = 2,
                    Status = true,
                }
            );
        }
    }
}
