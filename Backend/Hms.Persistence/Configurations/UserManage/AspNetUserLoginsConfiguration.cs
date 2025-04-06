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
    public class AspNetUserLoginsConfiguration : IEntityTypeConfiguration<AspNetUserLogins>
    {
        public void Configure(EntityTypeBuilder<AspNetUserLogins> builder)
        {
            builder.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                .HasName("PK_AspNetUserLogins");
        }
    }
}
