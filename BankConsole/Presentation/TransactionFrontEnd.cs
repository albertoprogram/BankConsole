﻿using BankConsole.Business;
using BankConsole.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

            ErrorManager errorManager = new ErrorManager();
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

                Menu menu = new Menu();

                menu.MenuPresentation();
            }
        }
        #endregion

        #region RequestTransactions
        internal void RequestTransactions()
        {
        Start:
            Console.WriteLine("\nView Transactions");

            Console.WriteLine("Select an option:");

            Console.WriteLine("1 By Period");
            Console.WriteLine("0 Main Menu");

            string? selectedOption = Console.ReadLine().Substring(0, 1);

            switch (selectedOption)
            {
                case "1":
                    RequestTransactionsByPeriod();
                    break;
                case "0":
                    Menu menu = new Menu();
                    menu.MenuPresentation();
                    break;
                default:
                    Console.WriteLine("Invalid option\n");
                    goto Start;
            }
        }
        #endregion

        #region RequestTransactionsByPeriod
        private void RequestTransactionsByPeriod()
        {
            Console.WriteLine("Enter start date");

            string? startDate = Console.ReadLine();

            Console.WriteLine("Enter the end date");

            string? endDate = Console.ReadLine();

            message = string.Empty;
            DataTable dataTable = new DataTable();

            ErrorManager errorManager = new ErrorManager();
            TransactionBusinessRules transactionBusinessRules = new TransactionBusinessRules();

            try
            {
                dataTable = transactionBusinessRules.TransactionRequestValidationsByPeriod(startDate, endDate, out message);

                if (message == "Ok")
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine
                            (
                            row["Id"].ToString() + "|" +
                            row["CustomerId"].ToString() + "|" +
                            row["TXNTypeId"].ToString() + "|" +
                            string.Format(CultureInfo.InvariantCulture,"{0:f2}", row["Amount"]) + "|" +
                            Convert.ToDateTime(row["DateAndTime"]).ToString("yyyy-MM-dd HH:mm:ss") + "|"
                            );
                    }

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(message);
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

                Menu menu = new Menu();

                menu.MenuPresentation();
            }
        }
        #endregion
    }
}
