namespace MultiThreadFileAccess
{
    /// <summary>
    /// FileHelper for operations related to file
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// A write method that writes content to a file specified by the filePath parameter.
        /// </summary>
        /// <param name="filePath">file path to write to</param>
        /// <param name="content">content for the file</param>
        public static void WriteToFile(string filePath, string content)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(content);
            }
        }
    }
}
