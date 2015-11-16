using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Cor.Base
{
    /// <summary>
    /// Abstract class representing a case
    /// </summary>
    /// <typeparam name="T">Type of case</typeparam>
    public abstract class BaseCase<T> : ICase<T> where T : IComparable, IConvertible, IEquatable<T>
    {
        /// <summary>
        /// The break on completion.
        /// </summary>
        protected bool BreakOnCompletion;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCase{T}"/> class.
        /// </summary>
        protected BaseCase()
            : this(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCase{T}"/> class.
        /// </summary>
        /// <param name="breakOnCompletion">
        /// The break on completion.
        /// </param>
        protected BaseCase(bool breakOnCompletion)
        {
            this.BreakOnCompletion = breakOnCompletion;
        }

        /// <summary>
        /// The of.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public abstract bool Of(T type);

        /// <summary>
        /// Initialized the object value when default constructor is invoked.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="ICase"/>.
        /// </returns>
        public abstract ICase<T> Init(T value);
    }
}
