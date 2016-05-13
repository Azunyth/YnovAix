using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Mappings
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {

        public PersonMapping()
        {
            this.ToTable(tableName: "Person", schemaName: "Domain").HasKey(p => p.Id);

            this.Property(p => p.Firstname).IsRequired();

            this.Property(p => p.Lastname).IsRequired();

            this.Property(p => p.Age).IsOptional();
        }

    }
}
