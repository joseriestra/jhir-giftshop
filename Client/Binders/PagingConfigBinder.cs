using Entities.Enums;
using Entities.TableConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Binders
{
    public class PagingConfigBinder: IModelBinder
    {
        /// <summary>
        /// Binds a PagingConfig Object with the form values
        /// </summary>
        /// <param name="controllerContext">Controller context</param>
        /// <param name="bindingContext">Binding context</param>
        /// <returns>PagincConfig Object binded</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Get the request info
            HttpRequestBase request = controllerContext.HttpContext.Request;

            string pageNum = request.QueryString["pagenum"];
            string pageSize = request.QueryString["pagesize"];
            string format = request.QueryString["format"];

            // params evaluation
            if (string.IsNullOrEmpty(pageNum))
            {
                throw new ArgumentException("Parameter 'pagenum' missing");
            }

            if (string.IsNullOrEmpty(pageSize))
            {
                throw new ArgumentException("Parameter 'pagesize' missing");
            }

            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentException("Parameter 'format', missing");
            }

            // Object creation
            return new PagingConfig()
            {
                PageNum = int.Parse(pageNum),
                PageSize = int.Parse(pageSize),
                Format = (ResponseFormat)int.Parse(format)
            };
        }
    }
}