
using MultiThreadFileAccess;

class Program
{
    //Initialized local variables for the application
    private static readonly object fileLock = new object();
    private static readonly string fileDirectory = "log/";
    private static readonly string fileName = "out.txt";
    private static int counter = 0;

    static async Task Main(string[] args)
    {
        //create directory if does not exists
        if (!Directory.Exists(fileDirectory))
            Directory.CreateDirectory(fileDirectory);
        //initialize new file with default text
        using (var fileStream = File.CreateText(fileDirectory + fileName))
        {
            fileStream.WriteLine($"{counter++}, 0, {DateTime.Now:HH:MM:ss.mmm}");
        }
        //create list of task to execute in parallel
        var tasksToExecuteInParallel = new List<Task>();

        // add new tasks to tasksToExecuteInParallel to execute all the task at once
        for (int i = 0; i < 10; i++)
        {
            tasksToExecuteInParallel.Add(Task.Run(() => WriteToFile()));
        }

        //Execute all the task and wait for all task to be complet
        await Task.WhenAll(tasksToExecuteInParallel);

        //Pause for user input to exit application
        Console.ReadLine();
    }

    static void WriteToFile()
    {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        try
        {
            //create 10 new rows for each thread
            for (int i = 0; i < 10; i++)
            {
                //use lock to ensure file is being access by one thread at a time for write
                lock (fileLock)
                {
                    //pass file path and file content to WriteToFile method to append in the file
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