using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Web.Controllers;
using Web.Utils;

namespace Web.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LoginController : BaseController
    {

        [Route("api/login")]
        [HttpPost]
        public IHttpActionResult Login(string account, string password)
        {
            try
            {
                User user = Factory.UserBusiness.FindUserByAccountAndPassword(account, password);
                HttpContext.Current.Session[SessionConstants.User] = user;
                return Ok("Login Correct!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }

        [HttpGet]
        [Route("api/login/logout")]
        public IHttpActionResult LogOut()
        {
            HttpContext.Current.Session[SessionConstants.User] = null;
            HttpContext.Current.Session.Abandon();
            return Ok("Signed out!");
        }
    }
}
