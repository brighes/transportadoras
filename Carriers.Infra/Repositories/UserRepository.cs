using Carriers.Domain.Entities;
using Carriers.Domain.Interfaces;
using Carriers.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carriers.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User GetByMail(string mail)
        {
            return GetAll().Where(x => x.Mail == mail).FirstOrDefault();
        }
    }
}
