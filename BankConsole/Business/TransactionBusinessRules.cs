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
            string? txnTypeId,
            string? amount,
            out string message
        )
        {
            Transaction transaction = new Transaction();

            if (!string.IsNullOrWhiteSpace(customerId))
            {
                transaction.CustomerId = customerId;
            }

            if (!string.IsNullOrWhiteSpace(txnTypeId))
            {
                transaction.TXNTypeId = txnTypeId;
            }

            if (!string.IsNullOrWhiteSpace(amount))
            {
                transaction.Amount = decimal.Parse(amount, CultureInfo.InvariantCulture);
            }

            TransactionData transactionData = new TransactionData();

            transactionData.SaveTransaction(transaction, out message);
        }
        #endregion

        internal void TransactionRequestValidationsByPeriod(string? startDate, string? endDate, out string message)
        {
            DateTime startDateDateTime = default(DateTime), endDateDateTime = default(DateTime);

            if (!string.IsNullOrWhiteSpace(startDate))
            {
                startDateDateTime = DateTime.Parse(startDate);
            }

            if (!string.IsNullOrWhiteSpace(endDate))
            {
                endDateDateTime = DateTime.Parse(endDate);
            }

            TransactionData transactionData = new TransactionData();

            transactionData.GetTransactionsByPeriod(startDateDateTime, endDateDateTime, out message);
        }
    }
}
