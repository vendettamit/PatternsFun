using ServiceOperations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOperations
{
    public static class CommandDispatcher
    {
        /// <summary>
        /// Keep the cached instance of command handlers.
        /// </summary>
        internal static Dictionary<Type, Object> localCache = new Dictionary<Type, object>();

        /// <summary>
        /// Register all the command handler found
        /// </summary>
        static CommandDispatcher()
        {
            // A DI container can be used here. 
            // This is a composite root for keeping command handlers only for demo purpose.
            var coreAssembly = typeof(ICommandHandler<,>).Assembly;

            var commandTypes =
                from type in coreAssembly.GetExportedTypes()
                where type.Name.EndsWith("CommandHandler")
                select type;


            // To increase the performance cache the handler instances
            commandTypes.ToList().ForEach(type => localCache[type] = GetInstance(type));
        }

        /// <summary>
        /// Method to locate and execute the command on their respective command handler.
        /// </summary>
        public static TResult Dispatch<THandler, TResult>(BaseCommand command)
        {
            var handlerType = typeof(THandler);

            var handlerInstance = Get<THandler>();

            var methodInfo = handlerType.GetMethod("Execute");

            return (TResult)methodInfo.Invoke(handlerInstance, new[] { command });
        }

        /// <summary>
        /// Get the registered command handlers.
        /// </summary>
        internal static THandler Get<THandler>()
        {
            object cachedInstance = null;

            if(!localCache.TryGetValue(typeof(THandler), out cachedInstance))
            {
                throw new InvalidOperationException("Command Handler for the respective command is not registered.");
            }

            return (THandler)cachedInstance;
        }

        /// <summary>
        /// For testing purpose only.
        /// </summary>
        internal static void ResetCache()
        {
            localCache.Clear();
        }

        private static object GetInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }

    class Dumped
    {
        //internal static object GenerateInstanceGeneric(Type type)
        //{
        //    var handlerType = type;
        //    Type[] typeargs = { typeof(BaseCommand), typeof(BaseCommandResult) };

        //    var maker = handlerType.MakeGenericType(typeargs);

        //    var handlerInstance = Activator.CreateInstance(maker);

        //    return handlerInstance;
        //}

        //internal static THandler Get<THandler>()
        //{
        //    object cachedInstance = null;

        //    if (!localCache.TryGetValue(typeof(THandler), out cachedInstance))
        //    {
        //        // fallback strategy, if a cached instance is not found.
        //        cachedInstance = GenerateInstanceGeneric(typeof(THandler));
        //        localCache[typeof(THandler)] = cachedInstance;
        //    }

        //    return (THandler)cachedInstance;
        //}

    }
}
