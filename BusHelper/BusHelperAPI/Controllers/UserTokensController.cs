using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusHelperDAL.Repository;
using BusHelperDAL;

namespace BusHelperAPI.Controllers
{
    public class UserTokensController : ApiController
    {

     //   private BusHelperEntities db = new BusHelperEntities();


        // Get api/UserTokens
        public IEnumerable<UserToken> GetUserTokens()
        {
            IUserTokenRepository db = new UserTokenRepository();
            var list = db.GetAll().ToList<UserToken>();
            return list;
        }
    }
}
