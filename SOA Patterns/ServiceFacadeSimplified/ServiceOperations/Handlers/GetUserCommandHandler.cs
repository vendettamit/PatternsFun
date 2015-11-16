using ServiceOperations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOperations
{
    public class GetUserCommandHandler : BaseCommandHandler<GetUserCommand, GetUserCommandResult>
    {
        protected override GetUserCommandResult ExecuteCore(GetUserCommand command)
        {
           // creating fake user but actually here the DAL object will be accessed to 
           // get the user details from persistance.

            if(command == null)
            {
                throw new ArgumentNullException("command", "Command should not be null.");
            }

            // Assuming this will be coming from repsoitory/DAL
            var userDetails = new GetUserCommandResult
            {
                UserDetails = new Domain.User
                {
                    LastName = "Parker",
                    FirstName = "Peter",
                    Id = command.UserId,
                    UserName = "yoda_03"
                }
            };

            return userDetails;
        }

        protected override GetUserCommandResult GenerateFailureResponse()
        {
            return new GetUserCommandResult
            {
                Error = new ErrorDetails
                    {
                        // Move it to shared constant file
                        Code = 200001,
                        // Load it from string resource file
                        Message = "There was an error while retreiving user details."
                    }
            };
        }
    }
}
