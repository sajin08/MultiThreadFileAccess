using MultiThreadFileAccess.Interfaces;
using MultiThreadFileAccess.Exceptions;

namespace MultiThreadFileAccess.Services
{
    /// <summary>
    /// This is an implementation of IEventLogger using a local file
    /// </summary>
    public class LocalFileLogger : IEventLogger
    {
        private static readonly object fileLock = new object();
        private static readonly string fileDirectory = "log/";
        private static readonly string fileName = "out.txt";
        private static int counter = 0;

        /// <summary>
        /// Initialization of the FileLogger
        /// </summary>
        /// <exception cref="EventLoggerInitException"></exception>
        public LocalFileLogger()
        {
            try
            {
                if (!Directory.Exists(fileDirectory))
                    Directory.CreateDirectory(fileDirectory);
                using (var fileStream = File.CreateText(fileDirectory + fileName))
                {
                    fileStream.WriteLine($"{counter++}, 0, {DateTime.Now:HH:MM:ss.mmm}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error during FileLogger initialization. details : {ex.Message}");
                throw new EventLoggerInitException("error during FileLogger initialization.");
            }
        }

        /// <inheritdoc />
        /// This implementation, using simple local file  will execute synchronously 
        public async Task LogThreadIdAsync()
        {
            try
            {
                lock (fileLock)
                {
                    using (StreamWriter writer = new StreamWriter(fileDirectory + fileName, true))
                    {
                        writer.WriteLine($"{counter++}, {Thread.CurrentThread.ManagedThreadId}, {DateTime.Now:HH:MM:ss.mmm}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error during LogThreadIdAsync LogThreadIdAsync. details : {ex.Message}");
                throw new EventLoggerLogException("error during LogThreadIdAsync LogThreadIdAsync.");
            }
            finally
            {
                //we can do some cleanup here
            }
        }
    }
}
