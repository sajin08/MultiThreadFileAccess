namespace MultiThreadFileAccess.Exceptions
{
    /// <summary>
    /// Exception that could be raide during the initialization of an IEventLogger method
    /// </summary>
    public class EventLoggerInitException : Exception
    {
        public EventLoggerInitException(string message) : base(message) { }
    }
}
