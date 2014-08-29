using System;

namespace PerfectMedia.ExternalApi
{
    /// <summary>
    /// Default RateGate that never blocks.
    /// </summary>
    public class NullRateGate : IRateGate
    {
        /// <summary>
        /// Blocks the current thread until allowed to proceed or until the
        /// specified timeout elapses.
        /// </summary>
        /// <param name="millisecondsTimeout">Number of milliseconds to wait, or -1 to wait indefinitely.</param>
        /// <returns>
        /// true if the thread is allowed to proceed, or false if timed out
        /// </returns>
        public bool WaitToProceed(int millisecondsTimeout)
        {
            return true;
        }

        /// <summary>
        /// Blocks the current thread until allowed to proceed or until the
        /// specified timeout elapses.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns>
        /// true if the thread is allowed to proceed, or false if timed out
        /// </returns>
        public bool WaitToProceed(TimeSpan timeout)
        {
            return true;
        }

        /// <summary>
        /// Blocks the current thread indefinitely until allowed to proceed.
        /// </summary>
        public void WaitToProceed()
        {
            // Do nothing
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do nothing
        }
    }
}