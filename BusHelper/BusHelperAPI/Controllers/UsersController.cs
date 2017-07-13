using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusHelperDAL;
using BusHelperDAL.Repository;
using System.Net.Http.Headers;

namespace BusHelperAPI.Controllers
{
    public class UsersController : ApiController
    {
        //// Get api/Users
        //public IQueryable<UserInfo> Login(String email)
        //{
        //    IUserInfoRepository db = new UserInfoRepository();
        //    var userInfo = db.FindBy(x => x.email.Equals(email));
        //    return userInfo;
        //}

        // Get api/Users
        public HttpResponseMessage Login(String email)
        {
            IUserInfoRepository db = new UserInfoRepository();
            var userInfo = db.FindBy(x => x.email.Equals(email)).FirstOrDefault();

            if (userInfo != null)
            {

                var res = new { UserToken = userInfo.UserTokens.FirstOrDefault().token, id = userInfo.id };

                var response = Request.CreateResponse(HttpStatusCode.OK, res);

                // Set headers for paging
                response.Headers.Add("access_token", res.UserToken);

                // Return the response
                return response;
            } else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
