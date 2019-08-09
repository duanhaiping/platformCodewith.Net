using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Infrastructure.User.Model
{
    public class UserDataInfo
    {
        public int ID { get; set; }
        public string LoginName { get; set; }
        public string UserName { get; set; }
        public int TelPhone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
