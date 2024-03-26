using BankConsole.Business;
using BankConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole.Presentation
{
    internal class TransactionFrontEnd
    {
        #region Variables
        string? customerId;
        string? txnId;
        string? amount;
        #endregion

        #region RequestTransactionData
        internal void RequestTransactionData()
        {
            Console.WriteLine("Transactions");

            Console.WriteLine("Enter customer Id");

            customerId = Console.ReadLine();

            Console.WriteLine("Enter the type of transaction");

            txnId = Console.ReadLine();

            Console.WriteLine("Enter the transaction amount");

            amount = Console.ReadLine();

            TransactionBusinessRules transactionBusinessRules = new TransactionBusinessRules();

            transactionBusinessRules.TransactionValidations
                (customerId, txnId, amount);
        }
        #endregion
    }
}
