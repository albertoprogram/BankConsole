using BankConsole.Business;
using BankConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole.Presentation
{
    internal class TransactionFrontEnd
    {
        #region Variables
        string? customerId;
        string? txnTypeId;
        string? amount;
        string? message;

        string logFilePath = AppDomain.CurrentDomain.BaseDirectory + @"Bank.log";
        #endregion

        #region RequestTransactionData
        internal void RequestTransactionData()
        {
            Console.WriteLine("\nEnter a Transaction");

            Console.WriteLine("Enter customer Id");

            customerId = Console.ReadLine();

            Console.WriteLine("Enter the type of transaction");

            txnTypeId = Console.ReadLine();

            Console.WriteLine("Enter the transaction amount");

            amount = Console.ReadLine();

            message = string.Empty;

            ErrorManager errorManager = new ErrorManager(logFilePath);
            TransactionBusinessRules transactionBusinessRules = new TransactionBusinessRules();

            try
            {
                transactionBusinessRules.TransactionValidations
                (customerId, txnTypeId, amount, out message);

                if (message == "Ok")
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("The transaction has been registered successfully");
                    Console.WriteLine("------------------------------------------------");
                    Console.ReadKey();
                }
            }
            catch (Exception exception)
            {
                errorManager.HandleError(exception);
                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("\n");
                Menu();
            }
        }
        #endregion

        #region Menu
        internal void Menu()
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
                        RequestTransactionData();
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
