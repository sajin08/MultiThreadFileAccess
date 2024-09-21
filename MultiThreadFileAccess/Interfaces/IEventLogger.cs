using MultiThreadFileAccess.Exceptions;

namespace MultiThreadFileAccess.Interfaces
{
    /// <summary>
    /// Provide methods to log events
    /// </summary>
    public interface IEventLogger
    {
        /// <summary>
        /// Would create a log entry for the current caller ThreadId
        /// </summary>
        /// <exception cref="EventLoggerLogException">Issue during the Log operation.</exception>
        Task LogThreadIdAsync();
    }
}
