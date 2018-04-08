using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Utils;
using System.IO;
using System.Text;
using Entities.Enums;
using System.Web.Routing;
using Web.Utils;
using System.Net;
using Entities.Classes;
using System.Web.SessionState;
using System.Web.Http;

namespace Web.Controllers
{
    public class BaseController : ApiController
    {
        private FactoryBusiness factory;

        public FactoryBusiness Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = new FactoryBusiness();
                }
                return factory;
            }
        }

        public string GetModelStateErros()
        {
            IEnumerable<string> errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            StringBuilder builder = new StringBuilder();
            builder.Append("<ul>");
            foreach (string error in errors)
            {
                builder.Append($"<li>error</li>");
            }
            builder.Append("</ul>");
            return builder.ToString();
        }

        public HttpError CreateHttpError(string message)
        {
            HttpError error = new HttpError(message);
            return error;
        }
    }
}
