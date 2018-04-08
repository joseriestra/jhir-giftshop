using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Enums;

namespace Entities.TableConfig
{
    /// <summary>
    /// Paging query result
    /// </summary>
    /// <typeparam name="TEntity">Entity type result</typeparam>
    public class PagingResult<TEntity>
    {
        /// <summary>
        /// Query rows
        /// </summary>
        public IList<TEntity> Rows { get; set; }
        /// <summary>
        /// Total rows count
        /// </summary>
        public long TotalRows { get; set; }
        /// <summary>
        /// Response format type
        /// </summary>
        public ResponseFormat Format { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="config"></param>
        public PagingResult(PagingConfig config)
        {
            Format = config.Format;
        }
        /// <summary>
        /// Create an empty paging query result
        /// </summary>
        /// <returns>Empty paging query result</returns>
        public static PagingResult<TEntity> CreateEmpty()
        {
            PagingConfig config = new PagingConfig() { Format = ResponseFormat.JSON };
            PagingResult<TEntity> result = new PagingResult<TEntity>(config);
            result.Rows = new List<TEntity>();
            result.TotalRows = 0;
            return result;
        }
    }
}
