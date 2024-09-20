namespace MultiThreadFileAccess
{
    public class FileHelper
    {
        public static void WriteToFile(string filePath, string content)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(content);
            }
        }
    }
}
