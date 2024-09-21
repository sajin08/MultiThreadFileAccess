using MultiThreadFileAccess.Interfaces;

namespace MultiThreadFileAccess.Services
{
    public class EventLogsGenerator : IProcessor
    {
        private readonly IEventLogger eventLogger;

        public EventLogsGenerator(IEventLogger eventLogger)
        {
            this.eventLogger = eventLogger;
        }

        /// <inheritdoc />
        public async Task RunAsync(int occurences)
        {
            try
            {
                for (int i = 0; i < occurences; i++)
                {
                    await this.eventLogger.LogThreadIdAsync();
                }
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed the {occurences} occurences.");
            }
            catch (Exception ex)
            {
                //we can log exception here using nlog or other logging framework
                Console.WriteLine($"Exception in Thread {Thread.CurrentThread.ManagedThreadId} {ex.Message}");
            }
            finally
            {
                //we can do some cleanup here
            }
        }
    }
}
