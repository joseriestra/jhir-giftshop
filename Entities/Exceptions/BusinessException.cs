using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    /// <summary>
    /// Clase especializda para el manejo de execpciones de negocio
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException() { }

        public BusinessException(string message) : base(message) { }

        [SecuritySafeCritical]
        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BusinessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
