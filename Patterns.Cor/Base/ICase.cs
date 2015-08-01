using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Cor.Base
{
    /// <summary>
    /// The Case interface.
    /// </summary>
    /// <typeparam name="T">type of case
    /// </typeparam>
    public interface ICase<T> where T : IComparable, IConvertible, IEquatable<T>
    {
        /// <summary>
        /// Allow to check the types
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Of(T type);

        /// <summary>
        /// Allows initialization the object value when default constructor is invoked.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="ICase"/>.
        /// </returns>
        ICase<T> Init(T value);
    }
}
