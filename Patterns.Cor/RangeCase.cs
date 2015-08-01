using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Patterns.Cor.Base;

namespace Patterns.Cor
{
    /// <summary>
    /// Concrete example of an advanced Case conditional to match a Range of values
    /// </summary>
    /// <typeparam name="TCase">type of input</typeparam>
    public class InRangeCase<TCase> : BaseCase<TCase> where TCase : IComparable, IConvertible, IEquatable<TCase>
    {
        /// <summary>
        /// The greate r_ than.
        /// </summary>
        private static readonly int GREATERTHAN = 1;

        /// <summary>
        /// The equals.
        /// </summary>
        private static readonly int EQUALS = 0;

        /// <summary>
        /// The les s_ than.
        /// </summary>
        private static readonly int LESSTHAN = -1;

        /// <summary>
        /// The start.
        /// </summary>
        protected readonly TCase Start;

        /// <summary>
        /// The end.
        /// </summary>
        protected readonly TCase End;

        /// <summary>
        /// Initializes a new instance of the <see cref="InRangeCase{TCase}"/> class.
        /// </summary>
        /// <param name="start">
        /// The start.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        public InRangeCase(TCase start, TCase end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InRangeCase{TCase}"/> class.
        /// </summary>
        /// <param name="start">
        /// The start.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <param name="breakOnCompletion">
        /// The break on completion.
        /// </param>
        public InRangeCase(TCase start, TCase end, bool breakOnCompletion)
            : base(breakOnCompletion)
        {
            this.Start = start;
            this.End = end;
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
        public override bool Of(TCase type)
        {
            return true;  // (type.(this.start) == EQUALS || type.compareTo(this.start) == GREATER_THAN) &&
            // (type.compareTo(this.end) == EQUALS || type.compareTo(this.end) == LESS_THAN);
        }

        public override ICase<TCase> Init(TCase value)
        {
            throw new NotImplementedException();
        }
    }
}
