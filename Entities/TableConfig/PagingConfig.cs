using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Enums;

namespace Entities.TableConfig
{
    /// <summary>
    /// Paging configuration
    /// </summary>
    public class PagingConfig
    {
        /// <summary>
        /// Current page number
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// Rows number per page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Response format type
        /// </summary>
        public ResponseFormat Format { get; set; }
    }
}
