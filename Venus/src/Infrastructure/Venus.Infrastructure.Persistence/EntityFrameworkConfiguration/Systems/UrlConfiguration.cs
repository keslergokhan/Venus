using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Systems;
using Venus.Infrastructure.Persistence.Constants;
using Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Base;

namespace Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Systems
{
    public class UrlConfiguration : BaseEntityLanguageConfiguration<Url>
    {
        public override void Configure(EntityTypeBuilder<Url> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FullPath)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv7);

            builder.Property(x => x.Path)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv7);

            builder.HasOne(x => x.ParentUrl)
                .WithMany(x => x.SubUrls)
                .HasForeignKey(x => x.ParentUrlId)
                .IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.IsEntity).IsRequired(true).HasDefaultValue<bool>(false);

        }
    }
}
