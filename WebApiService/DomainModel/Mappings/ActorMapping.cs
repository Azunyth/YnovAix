using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Mappings
{
    public class ActorMapping : EntityTypeConfiguration<Actor>
    {
        
        public ActorMapping()
        {
            this.ToTable(tableName: "Actors", schemaName: "Domain").HasKey(p => p.Id);

            this.Property(p => p.RealFirstname).IsRequired();

            this.Property(p => p.RealLastname).IsRequired();

            this.Property(p => p.MainShow).IsOptional();
        }

    }
}
