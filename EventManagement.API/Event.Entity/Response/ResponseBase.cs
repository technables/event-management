using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entity
{
    public abstract class ResponseBase
    {
        public StatusCode StatusCode { get; set; } = StatusCode.Ok;
        /// <summary>
        /// Clear message that defines the respose clearly
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Holds the result object to be transmitted
        /// </summary>
        public object Result { get; set; }
    }
}
