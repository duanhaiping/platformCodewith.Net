using Platform.Infrastructure.DataBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Platform.Infrastructure.User.Repositories
{
    public interface IUserRepository : IRepository<DBEFModel.User>
    {
    }
}
