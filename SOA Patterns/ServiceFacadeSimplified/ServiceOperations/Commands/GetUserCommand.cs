using ServiceOperations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ServiceOperations
{
    public class GetUserCommand : BaseCommand
    {
        public Guid UserId { get; private set; }

        public GetUserCommand(Guid userId)
        {
            this.UserId = userId;
        }
    }

    public class GetUserCommandResult : BaseCommandResult
    {
        public User UserDetails { get; set; }
    }
}
