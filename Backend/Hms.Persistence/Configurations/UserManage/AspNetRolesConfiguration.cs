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
    public class AspNetRolesConfiguration : IEntityTypeConfiguration<AspNetRoles>
    {
        public void Configure(EntityTypeBuilder<AspNetRoles> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_AspNetRoles");
        }
    }
}
