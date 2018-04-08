using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web.Controllers;

namespace Web.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CategoriesController : BaseController
    {
        [Route("api/categories")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IList<Category> categories = Factory.CategoryBusiness.FindAllCategories();
                if (categories.Count > 0)
                {
                    var model = categories.Select(m => new
                    {
                        Id = m.Id,
                        CategoryName = m.CategoryName,
                        Available = m.Available
                    });
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }
    }
}
