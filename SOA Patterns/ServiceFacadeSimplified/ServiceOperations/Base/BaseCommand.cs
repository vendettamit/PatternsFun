using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOperations.Base
{
    /// <summary>
    /// Each command would be dervied from Base command
    /// </summary>
    public abstract class BaseCommand
    {
        /// <summary>
        /// Logical name to represent the command.
        /// [optional] and can be used for other pusposes like logging/error reporting etc.
        /// </summary>
        public string Name { get; protected set; }
    }
}
