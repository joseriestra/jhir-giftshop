using Entities.Classes;
using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Web.Controllers;

namespace Web.Controllers
{
    /// <summary>
    /// Provides the Order Realization Functionality
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OrdersController : BaseController
    {
        [Route("api/orders")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IList<Order> orders = Factory.OrderBusiness.FindAllOrders();
                if (orders.Count > 0)
                {
                    var model = orders.Select(m => new
                    {
                        Id = m.Id,
                        OrderDate = m.OrderDate,
                        DeliveryOption = m.DeliveryOption,
                        Total = m.Total
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

        [Route("api/orders/{id}")]
        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            string[] relationShips = new string[]
            {
                "Products",
                "User"
            };
            try
            {
                Order order = Factory.OrderBusiness.FindById(id, relationShips);
                var model = new
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    DeliveryOption = order.DeliveryOption,
                    Total = order.Total,
                    Products = order.Products.Select(p => new
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        ProductCode = p.ProductCode,
                        Price = p.Price
                    })
                };
                return Ok(model);
            }
            catch (BusinessException e)
            {
                return Content(HttpStatusCode.NotFound, CreateHttpError(e.Message));
            }
        }

        [Route("api/orders/")]
        [HttpPost]
        [ResponseType(typeof(Order))]
        public IHttpActionResult Post([FromBody] Order order)
        {
            try
            {
                Factory.OrderBusiness.Save(order);
                return Ok("Your order has been done succesful!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }
        [Route("api/orders")]
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                Factory.OrderBusiness.Delete(id);
                return Ok("Order deleted Succesful.");
            }
            catch (BusinessException e)
            {
                return Content(HttpStatusCode.InternalServerError, CreateHttpError(e.Message));
            }
        }
    }
}
