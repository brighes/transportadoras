using Carriers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Infra.EntityConfig
{
    /// <summary>
    /// Configurações da entidade Carrier
    /// </summary>
    public class CarrierConfiguration: EntityTypeConfiguration<Carrier>
    {
        public CarrierConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome).IsRequired();

            Property(c => c.RazaoSocial);
        }
    }
}
