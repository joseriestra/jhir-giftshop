using Entities.Classes;
using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Web.Controllers;

namespace Web.Controllers
{
    /// <summary>
    /// Provides The Users Funcionality
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsersController : BaseController
    {
        [Route("api/users")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IList<User> users = Factory.UserBusiness.FindAllUsers();
                if (users.Count > 0)
                {
                    return Ok(users);
                }
                else
                {
                    return NotFound();
                }
            }            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            try
            {
                User user = Factory.UserBusiness.FindById(id);
                var model = new
                {
                    Id = user.Id,
                    Name = user.Name,
                    Account = user.Account,
                    Password = user.Password,
                    Available = user.Available
                };
                return Ok(model);
            }
            catch (BusinessException e)
            {
                return Content(HttpStatusCode.NotFound, CreateHttpError(e.Message));
            }
        }
        [Route("api/users")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult Post([FromBody] User user)
        {
            try
            {
                Factory.UserBusiness.Save(user);
                return Ok("User Saved Succesful.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }

        [Route("api/users")]
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                Factory.UserBusiness.Delete(id);
                return Ok("User Saved Succesful.");
            }
            catch (BusinessException e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }
    }
}
