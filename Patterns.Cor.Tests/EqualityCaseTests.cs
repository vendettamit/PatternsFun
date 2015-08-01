using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Patterns.Cor.Base;
using Patterns.Cor.Extension;

namespace Patterns.Cor.Tests
{
    /// <summary>
    /// Implements the tests for Switch class.
    /// </summary>
    [TestFixture]
    public class EqualityCaseTests
    {
        /// <summary>
        /// Test case when single value is compare with single argument of switch.
        /// </summary>
        [Test]
        public void EqualsCase_OfIntegers_CompareValuesCorrectly()
        {
            var origin = 2;

            var caseDirector = Switch.Build<int>().For<EqualsCase<int>>(origin);

             Assert.IsFalse(caseDirector.Evaluate(0).ContinueWith(() => Console.Write("Error of 0")));

             Assert.IsFalse(caseDirector.Evaluate(1).ContinueWith(() => Console.Write("Error of 1")));

             Assert.IsTrue(caseDirector.Evaluate(2).ContinueWith(() => Console.Write("Success of 2")));

             Assert.IsFalse(caseDirector.Evaluate(3).ContinueWith(() => Console.Write("Error of 3")));
        }

        /// <summary>
        /// Test case when single value is compare with single argument of switch.
        /// </summary>
        [Test]
        public void EqualsCase_OfIndividualIntegersButNoneMatches_InvokeDefaultCase()
        {
            var origin = 2;

            var caseDirector = Switch.Build<int>().For<EqualsCase<int>>(origin);

            Assert.IsFalse(caseDirector.Evaluate(0).ContinueWith(() => Console.Write("Error of 0")));

            Assert.IsFalse(caseDirector.Evaluate(1).ContinueWith(() => Console.Write("Error of 1")));

            Assert.IsTrue(caseDirector.Evaluate(2).ContinueWith(() => Console.Write("Success of 2")));

            Assert.IsFalse(caseDirector.Evaluate(3).ContinueWith(() => Console.Write("Error of 3")));
        }

        /// <summary>
        /// Test case when multiple values are being evaluated in single statement.
        /// </summary>
        [Test]
        public void SwitchHasCase_ThatFindsMatchInGivenRangeOfValues_DefaultCaseMustExecute()
        {
            var origin = "rocker";

            var caseDirector = Switch.Build<string>().For<EqualsCase<string>>(origin);

            Assert.IsTrue(
                caseDirector.Evaluate("Jazz", "pop", "rocker", "hello")
                            .ContinueWith(() => Console.Write("This worked pefectly. Rockers is matched.")));
        }

        /// <summary>
        /// Test case when a given range of values is evaluated with source and not case matched,
        /// Results in throwing an exception.
        /// </summary>
        [Test]
        public void SwitchHasCase_ThatDidnotMatchAnyValueInGivenRange_DefaultCaseMustExecute()
        {
            var origin = 12.01f;

            var caseDirector = Switch.Build<float>().For<EqualsCase<float>>(origin)
                   .DefaultCase(
                    () =>
                        {
                            throw new ArgumentOutOfRangeException("No value from evaluator matched");
                        });

            Assert.Throws<ArgumentOutOfRangeException>(
                () => caseDirector.Evaluate(1.1f, 2.3f, 3.44f, 5.22f)
                            .ContinueWith(() => Console.Write("This worked pefectly. Rockers is matched.")));
        }
    }
}
