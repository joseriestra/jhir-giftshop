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
    /// <summary>
    /// Provides the Categories Functionality.
    /// </summary>
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

        [Route("api/categories/{id}")]
        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            try
            {
                IList<Product> products = Factory.ProductBusiness.FindProductsByCategoryId(id);
                if (products.Count > 0)
                {
                    var model = products.Select(m => new
                    {
                        Id = m.Id,
                        ProductName = m.ProductName,
                        ProductCode = m.ProductCode,
                        Description = m.Description,
                        Price = m.Price,
                        ImagePath = m.ImagePath,
                        CategoryId = m.CategoryId
                    });
                    return Ok(model);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, CreateHttpError("The selected category does not have any product."));
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }
    }
}
