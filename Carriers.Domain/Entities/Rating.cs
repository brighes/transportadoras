using Carriers.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        public ERatingCarrier AgilidadeNaEntrega { get; set; }
        public ERatingCarrier Transparencia { get; set; }
        public ERatingCarrier BoaComunicacao { get; set; }
        public ERatingCarrier CuidadoComMercadoria { get; set; }

        public virtual Carrier Carrier { get; set; }
        public virtual User User { get; set; }
    }
}
