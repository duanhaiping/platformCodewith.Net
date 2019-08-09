using Microsoft.Practices.Unity;
using Platform.Infrastructure.User.Interface;
using Platform.Infrastructure.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service.User.Services
{
    public class TestService : ITestService
    {

        [Dependency]
        public IUserRepository UserRepository { get; set; }

        public void test()
        {
            var s = UserRepository.Find(1);
        }
    }
}
