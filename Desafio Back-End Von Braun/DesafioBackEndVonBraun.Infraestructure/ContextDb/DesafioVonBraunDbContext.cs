
using DesafioBackEndVonBraun.Infraestructure.DatabaseEntity;
using DesafioBackEndVonBraun.Infraestrutura.DatabaseEntity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Infraestrutura.ContextDb
{
    public class DesafioVonBraunDbContext(DbContextOptions<DesafioVonBraunDbContext> options) : DbContext(options)
    {
        public DbSet<DeviceEntity> Devices {  get; set; }
        public DbSet<UserEntity> Users { get; set;}

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

                        foreach (var entityEntry in entries)
                        {
                            ((Entity)entityEntry.Entity).LastUpdateDate = DateTime.UtcNow;
                        }

            foreach (var entry in entries)
            {

                if (entry.Entity  != null)
                    ((Entity)entry.Entity).LastUpdateDate = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
