using MultiThreadFileAccess.Exceptions;

namespace MultiThreadFileAccess.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IProcessor
    {
        /// <summary>
        /// Will run the process and repeat the action
        /// </summary>
        /// <param name="occurences">number of time to repeat the action</param>
        Task RunAsync(int occurences);
    }
}
