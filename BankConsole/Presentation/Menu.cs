using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole.Presentation
{
    internal class Menu
    {
        #region Variables
        string logFilePath = AppDomain.CurrentDomain.BaseDirectory + @"Bank.log";
        #endregion

        #region MenuPresentation
        internal void MenuPresentation()
        {
        Start:
            Console.WriteLine("-------Bank-------");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 Enter a Transaction");
            Console.WriteLine("0 Exit");

            ErrorManager errorManager = new ErrorManager(logFilePath);

            try
            {
                string selectedOption = Console.ReadLine().Substring(0, 1);

                switch (selectedOption)
                {
                    case "1":
                        TransactionFrontEnd transactionFrontEnd = new TransactionFrontEnd();
                        transactionFrontEnd.RequestTransactionData();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option\n");
                        goto Start;
                }
            }
            catch (Exception exception)
            {
                errorManager.HandleError(exception);
                Console.ReadKey();
                Console.WriteLine("\n");
                goto Start;
            }
        }
        #endregion
    }
}
