using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.VenusDbContext.Interfaces;
using Venus.Core.Domain.Entities;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Infrastructure.Persistence.VenusDbContext
{
    public class VenusContext : DbContext, IVenusApplicationDbContext
    {
        public VenusContext(DbContextOptions<VenusContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        #region VenusSystems
        public DbSet<VenusEntityDataUrl> VenusEntityDataUrl { get; set; }
        public DbSet<VenusLanguage> VenusLanguage { get; set; }
        public DbSet<VenusLocalization> VenusLocalization { get; set; }
        public DbSet<VenusPage> VenusPage { get; set; }
        public DbSet<VenusPageAbout> VenusPageAbout { get; set; }
        public DbSet<VenusPageType> VenusPageType { get; set; }
        public DbSet<VenusUrl> VenusUrl { get; set; }
        public DbSet<VenusUser> VenusUser { get; set; }
        #endregion VenusSystems End
        public DbSet<Blog> Blogs { get; set; }  
    }
}
