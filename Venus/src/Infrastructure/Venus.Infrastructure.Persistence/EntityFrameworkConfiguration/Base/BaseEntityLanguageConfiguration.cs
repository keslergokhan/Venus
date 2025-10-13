using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Interfaces;
using Venus.Core.Application.Entities.Systems;

namespace Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Base
{
    public abstract class BaseEntityLanguageConfiguration<T> 
        : BaseEntityConfiguration<T> where T : class, IEntityLanguage
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Language).WithMany().HasForeignKey(x => x.LanguageId);
        }
    }
}
