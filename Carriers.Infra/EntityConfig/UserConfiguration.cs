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
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Mail).IsRequired();

            Property(c => c.Password).IsRequired();
        }
    }
}
