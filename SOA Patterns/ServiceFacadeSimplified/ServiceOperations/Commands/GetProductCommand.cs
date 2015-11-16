using Domain;
using ServiceOperations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOperations.Commands
{
    /// <summary>
    /// Contains arguments and information required to process Get product request.
    /// </summary>
    public class GetProductCommand : BaseCommand
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public Guid ProductId { get; set; }

        public GetProductCommand(Guid productId)
        {
            this.ProductId = productId;

            this.DoSanityCheckOnArguments();
        }

        private void DoSanityCheckOnArguments()
        {
            if(this.ProductId == Guid.Empty)
            {
                throw new ArgumentException("productId", "Failed to initialize GetProductCommand. Invalid product Id received.");
            }
        }
    }

    /// <summary>
    /// Contains results of GetProductCommand execution.
    /// </summary>
    public class GetProductCommandResult : BaseCommandResult
    {
        public Product ProductDetails { get; set; }
    }
}
