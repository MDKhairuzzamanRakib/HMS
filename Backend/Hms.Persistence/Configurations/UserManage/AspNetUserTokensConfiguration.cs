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
    public class AspNetUserTokensConfiguration : IEntityTypeConfiguration<AspNetUserTokens>
    {
        public void Configure(EntityTypeBuilder<AspNetUserTokens> builder)
        {
            builder.HasKey(e => new { e.UserId , e.LoginProvider , e.Name})
                .HasName("PK_AspNetUserTokens");
        }
    }
}
