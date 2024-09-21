using Microsoft.Extensions.DependencyInjection;
using MultiThreadFileAccess.Exceptions;
using MultiThreadFileAccess.Interfaces;
using MultiThreadFileAccess.Services;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IEventLogger>(new LocalFileLogger())
                .AddTransient<IProcessor, EventLogsGenerator>()
                .BuildServiceProvider();

            var tasksToExecuteInparallel = new List<Task>();

            // Create and start multiple threads
            for (int i = 0; i < 10; i++)
            {
                tasksToExecuteInparallel.Add(Task.Run(() => serviceProvider.GetRequiredService<IProcessor>().RunAsync(10)));
            }

            await Task.WhenAll(tasksToExecuteInparallel);

            Console.WriteLine("All Threads done.");
        }
        catch (EventLoggerInitException ex)
        {
            Console.WriteLine($"The EventLogger initialization encountered an inexpected Issue. {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"The process encountered an inexpected Issue. {ex.GetType()} {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Execution completed. Press a key");
            Console.ReadKey();
        }
    }
}