using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
