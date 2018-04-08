using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Controllers;
using Entities.Classes;
using Entities.Exceptions;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace Web.Controllers
{
    /// <summary>
    /// Provides The Products Functionality
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductsController : BaseController
    {
        [Route("api/products")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IList<Product> products = Factory.ProductBusiness.FindAllProducts();
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
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }

        [Route("api/products/{id}")]
        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            try
            {
                Product product = Factory.ProductBusiness.FindById(id);
                var model = new
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductCode = product.ProductCode,
                    Description = product.Description,
                    Price = product.Price,
                    ImagePath = product.ImagePath,
                    CategoryId = product.CategoryId,
                    Available = product.Available
                };
                return Ok(model);
            }
            catch (BusinessException e)
            {
                return Content(HttpStatusCode.NotFound, CreateHttpError(e.Message));
            }
        }

        [Route("api/products/")]
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody] Product product)
        {
            try
            {
                Factory.ProductBusiness.Save(product);
                return Ok("Product Saved Succesful.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                Factory.UserBusiness.Delete(id);
                return Ok("Product Deleted Succesful.");
            }
            catch (BusinessException e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }

        [Route("api/products/{categoryId}")]
        [HttpGet]
        public IHttpActionResult GetByCategory(long categoryId)
        {
            try
            {
                IList<Product> products = Factory.ProductBusiness.FindProductsByCategoryId(categoryId);
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
