using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Patterns.Cor.Base;

namespace Patterns.Cor
{
    /// <summary>
    /// Equality Case comparer for all primitive types supported in C#.
    /// </summary>
    /// <typeparam name="T">type to accept</typeparam>
    public class EqualsCase<T> : BaseCase<T> where T : IComparable, IConvertible, IEquatable<T>
    {
        /// <summary>
        /// The type of given case
        /// </summary>
        private T type;

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualsCase{T}"/> class.
        /// </summary>
        public EqualsCase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualsCase{T}"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        public EqualsCase(T type)
        {
            this.type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualsCase{T}"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="breakOnCompletion">
        /// The break on completion.
        /// </param>
        public EqualsCase(T type, bool breakOnCompletion)
            : base(breakOnCompletion)
        {
            this.type = type;
        }

        /// <summary>
        /// The of.
        /// </summary>
        /// <param name="caseType">
        /// The case Type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Of(T caseType)
        {
            if (this.type.Equals(caseType))
            {
                // Console.Write("Case {0}, break = {1}\n", caseType, this.BreakOnCompletion);
                return this.BreakOnCompletion;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Initialized the object value when default constructor is invoked.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="ICase"/>.
        /// </returns>
        public override ICase<T> Init(T value)
        {
            this.type = value;

            return this;
        }
    }
}
