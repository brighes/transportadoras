using Carriers.Domain.Entities;
using Carriers.Infra.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Infra.Context
{
    public class CarrierContext: DbContext
    {
        public CarrierContext()
            :base("CarriersProjectContext")
        {}

        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Properties()
                        .Where(p => p.Name == "Id")
                        .Configure(p => p.IsKey());

            //modelBuilder.Entity<Rating>()
            //  .HasRequired(x => x.Carrier)
            //  .WithOptional(x => x.Rating)
            //  .WillCascadeOnDelete(true);

            modelBuilder.Configurations.Add(new CarrierConfiguration());
        }
    }
}
