using DomainModel;
using DomainModel.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonContext : DbContext
    {

        public DbSet<BusinessMan> BusinessMans { get; set; }

        public DbSet<Actor> Actors { get; set; }

        static PersonContext() {
            Database.SetInitializer<PersonContext>(new PersonInitializer());
        }

        public PersonContext() : base("People") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Configuration");

            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Configurations.Add(new BusinessManMapping());
            modelBuilder.Configurations.Add(new ActorMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
