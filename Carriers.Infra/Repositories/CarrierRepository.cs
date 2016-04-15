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
    {
        public void Remove(Carrier carrier)
        {
            var ratings = Db.Set<Rating>().Where(x => x.Carrier.Id == carrier.Id).ToList();
            foreach(var item in ratings)
            {
                Db.Set<Rating>().Remove(item);
            }
            Db.Set<Carrier>().Remove(carrier);
            Db.SaveChanges();
        }       
    }
}
