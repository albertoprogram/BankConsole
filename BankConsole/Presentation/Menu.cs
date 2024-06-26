﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole.Presentation
{
    internal class Menu
    {
        #region MenuPresentation
        internal void MenuPresentation()
        {
        Start:
            Console.WriteLine("-------Bank-------");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 Enter a Transaction");
            Console.WriteLine("2 View Transactions");
            Console.WriteLine("0 Exit");

            ErrorManager errorManager = new ErrorManager();

            try
            {
                TransactionFrontEnd transactionFrontEnd = new TransactionFrontEnd();

                string selectedOption = Console.ReadLine().Substring(0, 1);

                switch (selectedOption)
                {
                    case "1":
                        transactionFrontEnd.RequestTransactionData();
                        break;
                    case "2":
                        transactionFrontEnd.RequestTransactions();
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
