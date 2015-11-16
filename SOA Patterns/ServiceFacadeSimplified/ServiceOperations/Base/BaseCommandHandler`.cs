using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOperations
{
    /// <summary>
    /// A marker interface for CommandHandlers.
    /// </summary>
    public interface ICommandHandler<TCommand, TResult>
    {
        TResult Execute(TCommand command);
    }

    /// <summary>
    /// Each command handler must be dervied from this class.
    /// </summary>
    public abstract class BaseCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    {
        /// <summary>
        /// Executes the command logic in safe execution context.
        /// </summary>
        public TResult Execute(TCommand command)
        {
            try
            {
                return this.ExecuteCore(command);
            }
            catch(Exception exception)
            {
                this.HandleException(exception);

                return this.GenerateFailureResponse();
            }
        }

        /// <summary>
        /// Consists of actual logic to process any command.
        /// </summary>
        protected abstract TResult ExecuteCore(TCommand command);

        /// <summary>
        /// Consists of dervied handler specific strategy to respond to 
        /// any error occurred during execution.
        /// </summary>
        protected abstract TResult GenerateFailureResponse();

        /// <summary>
        /// Method detailing the handling of exception.
        /// Override this method to have CommandHandler specific error handling.
        /// </summary>
        protected virtual void HandleException(Exception exception)
        {
            // do logging
        }
    }
}
