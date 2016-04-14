using Carriers.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carriers.Mvc.ViewModels
{
    public class RatingVm
    {
        public int Id { get; set; }

        [Required]
        public ERatingCarrier AgilidadeNaEntrega { get; set; }
        [Required]
        public ERatingCarrier Transparencia { get; set; }
        [Required]
        public ERatingCarrier BoaComunicacao { get; set; }
        [Required]
        public ERatingCarrier CuidadoComMercadoria { get; set; }
        public int IdCarrier { get; internal set; }
    }
}