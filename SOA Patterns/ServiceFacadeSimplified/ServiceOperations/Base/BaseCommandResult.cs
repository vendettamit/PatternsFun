using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOperations.Base
{
    /// <summary>
    /// Each command must have a result to send back. 
    /// Any command restul must inherit from this class.
    /// </summary>
    public abstract class BaseCommandResult
    {
        /// <summary>
        /// Contains error details, if occurred during execution.
        /// </summary>
        public ErrorDetails Error { get; set; }
    }
}
