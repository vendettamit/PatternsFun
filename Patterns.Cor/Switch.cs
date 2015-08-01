using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Patterns.Cor.Base;

namespace Patterns.Cor
{
    /// <summary>
    /// Generic enabled Object Oriented Switch/Case construct
    /// </summary>
    /// <typeparam name="T">type to switch on</typeparam>
    public class Switch<T> where T : IComparable, IConvertible, IEquatable<T>
    {
        /// <summary>
        /// The cases.
        /// </summary>
        private List<ICase<T>> cases;

        /// <summary>
        /// The default case action.
        /// </summary>
        private Action defaultCaseAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="Switch{T}"/> class.
        /// </summary>
        public Switch()
        {
            this.cases = new List<ICase<T>>();
        }

        /// <summary>
        /// Register the Cases with the Switch
        /// </summary>
        /// <param name="case">
        /// The case.
        /// </param>
        public void Register(ICase<T> @case)
        {
            this.cases.Add(@case);
        }

        /// <summary>
        /// The for value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="TCase">
        /// type of case comparer
        /// </typeparam>
        public Switch<T> For<TCase>(T value) where TCase : ICase<T>, new()
        {
            this.cases.Add(new TCase().Init(value));

            return this;
        }

        /// <summary>
        /// The default case. Use it when you have a array of values to evaluate.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <returns>
        /// The <see cref="Switch"/>.
        /// </returns>
        public Switch<T> DefaultCase(Action action = null)
        {
            this.defaultCaseAction = action;
            return this;
        }

        /// <summary>
        /// Run the switch logic on some input and break the case if the evaluation results in success.
        /// </summary>
        /// <remarks>
        /// Use evaluate for individual values when you want to have continue with for each evaluation.
        /// </remarks>
        /// <param name="type">
        /// input to Switch on
        /// </param>
        public bool Evaluate(T type)
        {
            foreach (var @case in this.cases)
            {
                if (@case.Of(type))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Run the switch logic on some input and break the case if the evaluation results in success.
        /// </summary>
        /// <param name="type">
        /// input to Switch on
        /// </param>
        public bool Evaluate(params T [] caseValues)
        {
            foreach (var @case in this.cases)
            {
                foreach (var value in caseValues)
                {
                    if (@case.Of(value))
                    {
                        return true;
                    }
                }
            }

            // Invoke the default case.
            if (this.defaultCaseAction != null)
            {
                this.defaultCaseAction.Invoke();
            }

            return false;
        }
    }
}
