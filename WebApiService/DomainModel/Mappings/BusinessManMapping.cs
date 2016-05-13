using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Mappings
{
    public class BusinessManMapping : EntityTypeConfiguration<BusinessMan>
    {
        public BusinessManMapping()
        {
            this.ToTable(tableName: "BusinessMan", schemaName: "Domain").HasKey(d => d.Id);

            this.Property(p => p.NetWorth).IsRequired();

            this.Property(p => p.MainCompany).IsRequired();

            this.Property(p => p.IsRetired).IsRequired();
        }
    }
}
