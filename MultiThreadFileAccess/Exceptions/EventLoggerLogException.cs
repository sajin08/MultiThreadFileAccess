namespace MultiThreadFileAccess.Exceptions
{
    /// <summary>
    /// Exception that could be raide during a Log operation of an IEventLogger method
    /// </summary>
    public class EventLoggerLogException : Exception
    {
        public EventLoggerLogException(string message) : base(message) { }
    }
}
