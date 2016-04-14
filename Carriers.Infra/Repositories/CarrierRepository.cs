using Carriers.Domain.Entities;
using Carriers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Infra.Repositories
{
    public class CarrierRepository : RepositoryBase<Carrier>, ICarrierRepository
    {}
}
