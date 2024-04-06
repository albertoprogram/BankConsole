using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    internal class ErrorManager
    {
        #region Variables
        private string logFilePath;
        #endregion

        #region Constructors
        public ErrorManager(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }
        #endregion

        #region LogError
        public void LogError(Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Error: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine();
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Error when trying to write to the log file: {logEx.Message}");
            }
        }
        #endregion

        #region HandleError
        public void HandleError(Exception ex)
        {
            LogError(ex);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("There was an error. See the log file for more details.");
            Console.WriteLine("------------------------------------------------------");
        }
        #endregion
    }
}
