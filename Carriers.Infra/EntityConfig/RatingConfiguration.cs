﻿using Carriers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Infra.EntityConfig
{
    /// <summary>
    /// Configurações da entidade Rating
    /// </summary>
    public class RatingConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.AgilidadeNaEntrega).IsRequired();

            Property(c => c.BoaComunicacao).IsRequired();

            Property(c => c.CuidadoComMercadoria).IsRequired();

            Property(c => c.Transparencia).IsRequired();

            HasRequired(c => c.Carrier).WithMany().Map(x => x.MapKey("IdCarrier"));

            HasRequired(c => c.User).WithMany().Map(x => x.MapKey("IdUser"));

            HasOptional(a => a.Carrier)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true);

            HasOptional(a => a.User)
               .WithOptionalDependent()
               .WillCascadeOnDelete(true);
        }
    }
}
