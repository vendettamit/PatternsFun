using ServiceOperations.Base;
using ServiceOperations.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ServiceOperations.Handlers
{
    public class GetProductCommandHandler : BaseCommandHandler<GetProductCommand, GetProductCommandResult>
    {
        private IRepository repository;

        public GetProductCommandHandler()
        {
            repository = new ProductRepository();
        }

        protected override GetProductCommandResult ExecuteCore(GetProductCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command", "GetProductCommand object was received null.");
            }

            var product = repository.Fetch(command.ProductId);

            var productDetails = new GetProductCommandResult
            {
               ProductDetails = product
            };

            return productDetails;
        }

        protected override GetProductCommandResult GenerateFailureResponse()
        {
            return new GetProductCommandResult
            {
                Error = new ErrorDetails
                {
                    // Move it to shared constant file
                    Code = 200001,
                    // Load it from string resource file
                    Message = "There was an error while retreiving product details."
                }
            };
        }
    }
}
