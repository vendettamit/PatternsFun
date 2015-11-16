using ServiceOperations;
using System;
using WcfRestAuthentication.Model;
using WcfRestAuthentication.Services.Api.Endpoints.User;

namespace WcfRestAuthentication.Services.Api
{
    public partial class ApiService : IUserService
    {
        #region IUserService

        public User Get(Guid userId)
        {
            var commandArgs = new GetUserCommand(userId);

            GetUserCommandResult result = 
                CommandDispatcher.Dispatch<GetUserCommandHandler, GetUserCommandResult>(commandArgs);

            // Raise the fault exception
            if(result.Error != null)
            {
                throw new System.ServiceModel.FaultException<Exception>(new Exception(result.Error.Message));
            }

            return new User
            {
               FirstName = result.UserDetails.FirstName,
               Id = result.UserDetails.Id,
               LastName = result.UserDetails.LastName,
               UserName = result.UserDetails.UserName
            };
        }

        public User Post(User user)
        {
            return user;
        }

        public User Put(User user)
        {
            return user;
        }

        public void Delete(Guid userId)
        {
        }

        #endregion IUserService

        #region Privates

        private User CreateTestUser(Guid userId)
        {
            return User.Create(userId, "TestUser", "Test", "User");
        }

        #endregion Privates
    }

}
