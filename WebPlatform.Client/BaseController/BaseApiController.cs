using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebPlatform.Client.BaseController
{
    public class BaseApiController : ApiController
    {
        public int CurrentUser
        {
            get
            {
                return 0;
            }
        }

        public int CurrentProject
        {
            get
            {
                return 0;
            }
        }
    }
}