using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Domain.Entities
{
    public class Carrier
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public Endereco Endereco { get; set; }
        public bool AvaliadaPeloUsuario { get; set; }
        
        //public List<Rating> Ratings { get; set; }
    }
}
