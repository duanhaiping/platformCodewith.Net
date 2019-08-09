using Platform.Core.DataBaseRepository;
using Platform.Infrastructure.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service.User.Repositories
{
    public class UserRepository : EFRepository<DBEFModel.User>, IUserRepository
    {
        public UserRepository() : base()
        {

        }
    }
}
