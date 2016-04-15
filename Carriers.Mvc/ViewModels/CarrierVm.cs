using Carriers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carriers.Mvc.ViewModels
{
    public class CarrierVm
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public Endereco Endereco { get; set; }
        public bool AvaliadaPeloUsuario { get; set; }
    }
}