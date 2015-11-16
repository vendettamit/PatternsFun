using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Cor
{
    /// <summary>
    /// The switch.
    /// </summary>
    public sealed class Switch
    {
        /// <summary>
        /// static constructor to prevent object creation.
        /// </summary>
        static Switch() { } 

        /// <summary>
        /// Create a switch object
        /// </summary>
        /// <typeparam name="T"> case type for switch 
        /// </typeparam>
        /// <returns>
        /// The <see cref="Switch"/>.
        /// </returns>
        public static Switch<T> Build<T>() where T : IComparable, IConvertible, IEquatable<T>
        {
            return new Switch<T>();
        }
    }
}
