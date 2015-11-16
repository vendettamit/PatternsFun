using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceOperations.Base
{
    /// <summary>
    /// Represent error details happened during command execution.
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Error code, For production level debugging purpose(representing technical issue type).
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Application friendly error message.
        /// </summary>
        public string Message { get; set; }
    }
}
