using Carriers.Domain.Entities;
using Carriers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Infra.Repositories
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public Rating GetRatingBy(int idUser, int idCarrier)
        {
            return Db.Set<Rating>().Where(x => x.Carrier.Id == idCarrier && x.User.Id == idUser).FirstOrDefault();
        }

        public void Add(Rating rating)
        {
            Db.Entry(rating).State = EntityState.Added;
            Db.Entry(rating.User).State = EntityState.Modified;
            Db.Entry(rating.Carrier).State = EntityState.Modified;
            Db.SaveChanges();
        }

    }
}
