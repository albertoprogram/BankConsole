using BankConsole.DataAccess;
using BankConsole.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole.Business
{
    internal class TransactionBusinessRules
    {
        #region TransactionValidations
        internal void TransactionValidations
        (
            string? customerId,
            string? txnId,
            string? amount
        )
        {
            Transaction transaction = new Transaction();

            if (!string.IsNullOrWhiteSpace(customerId))
            {
                transaction.CustomerId = customerId;
            }

            if (!string.IsNullOrWhiteSpace(txnId))
            {
                transaction.TXNId = txnId;
            }

            if (!string.IsNullOrWhiteSpace(amount))
            {
                transaction.Amount = decimal.Parse(amount, CultureInfo.InvariantCulture);
            }

            TransactionData transactionData = new TransactionData();

            transactionData.SaveTransaction(transaction);
        }
        #endregion
    }
}
