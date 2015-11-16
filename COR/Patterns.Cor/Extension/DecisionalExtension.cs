using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Cor.Extension
{
    /// <summary>
    /// The decisional extension.
    /// </summary>
    public static class DecisionalExtension
    {
        /// <summary>
        /// Executes the delegate if the Evaluation returns true.
        /// </summary>
        /// <param name="successFlag">
        /// The success flag.
        /// </param>
        /// <param name="activityBlock">
        /// The activity block.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ContinueWith(this bool successFlag, Action activityBlock)
        {
            if (successFlag)
            {
                activityBlock.Invoke();                
            }

            return successFlag;
        }
    }
}
