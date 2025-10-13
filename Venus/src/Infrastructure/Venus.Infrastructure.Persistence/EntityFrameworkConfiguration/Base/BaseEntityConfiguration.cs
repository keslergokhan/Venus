using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Interfaces;

namespace Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Base
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(typeof(T).Name);
            builder.Property(x => x.Id).HasColumnOrder(0);

            builder
                .Property(x => x.ModifiedDate)
                .IsRequired(false)
                .HasColumnOrder(999);

            builder
                .Property(x => x.CreateDate)
                .IsRequired(true)
                .HasColumnOrder(998);

            builder.Property(x => x.State)
                .IsRequired(true)
                .HasColumnOrder(9999);
        }


        protected void UrlConfigure<T>(EntityTypeBuilder<T> builder)
            where T : class, IEntity, IUrlEntity
        {
            builder.HasOne(x => x.Url)
                .WithMany()
                .HasForeignKey(x => x.UrlId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected void ImageConfigure<T>(EntityTypeBuilder<T> builder) where T : class, IEntity, IEntityImage
        {
            builder.Property(x => x.Image)
                .IsRequired(false)
                .HasMaxLength(500)
                .HasColumnOrder(99);
        }
    }
}
