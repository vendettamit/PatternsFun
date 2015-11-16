using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOperations.Tests
{
    [TestFixture]
    public class CommandDispatcherTests
    {
        [Test]
        public void Dispatcher_InvokesExecutes_Succeed()
        {
            GetUserCommandResult result 
                = CommandDispatcher.Dispatch<GetUserCommandHandler, GetUserCommandResult>(new GetUserCommand(Guid.NewGuid()));

            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
        }

        [Test]
        public void Dispatcher_SendsNullCommandToHandler_ErroReturned()
        {
            GetUserCommandResult result
                 = CommandDispatcher.Dispatch<GetUserCommandHandler, GetUserCommandResult>(null);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Error);
            Assert.IsNotNullOrEmpty(result.Error.Message);
        }
    }
}
