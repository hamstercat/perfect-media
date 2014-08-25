using System;
using System.Threading.Tasks;
using Anotar.Log4Net;

namespace PerfectMedia.UI
{
    /// <summary>
    /// Base class for ICommand asynchronous implementations.
    /// </summary>
    public abstract class AsyncCommand : IAsyncCommand
    {
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public abstract event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Defines the method to be called asynchronously when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns></returns>
        public abstract Task ExecuteAsync(object parameter);

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public async void Execute(object parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                LogTo.ErrorException("Unhandled exception in async command " + GetType().FullName, ex);
            }
        }
    }
}
