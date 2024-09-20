
using MultiThreadFileAccess;

class Program
{
    private static readonly object fileLock = new object();
    private static readonly string fileDirectory = "log/";
    private static readonly string fileName = "log.txt";
    private static int counter = 0;

    static async Task Main(string[] args)
    {
        if (!Directory.Exists(fileDirectory))
            Directory.CreateDirectory(fileDirectory);
        using (var fileStream = File.CreateText(fileDirectory + fileName))
        {
            fileStream.WriteLine($"{counter++}, 0, {DateTime.Now:HH:MM:ss.mmm}");
        }
        var tasksToExecuteInParallel = new List<Task>();

        // Create and start multiple threads
        for (int i = 0; i < 10; i++)
        {
            tasksToExecuteInParallel.Add(Task.Run(() => WriteToFile()));
        }

        await Task.WhenAll(tasksToExecuteInParallel);

        Console.ReadLine();
    }

    static void WriteToFile()
    {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        try
        {
            for (int i = 0; i < 10; i++)
            {
                lock (fileLock)
                {
                    FileHelper.WriteToFile(fileDirectory + fileName, $"{counter++}, {threadId}, {DateTime.Now:HH:MM:ss.mmm}");
                }
            }
        }
        catch (Exception ex)
        {
            //we can log exception here using nlog or other logging framework
            Console.WriteLine(ex.Message);
        }
        finally
        {
            //we can do some cleanup here
        }
    }

}