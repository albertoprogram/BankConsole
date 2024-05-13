using BankConsole.DataAccess;
using BankConsole.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

        #region TransactionRequestValidationsByPeriod
        internal DataTable TransactionRequestValidationsByPeriod(string? startDate, string? endDate, out string message)
        {
            string startDateAndTime = "0001-01-01T00:00:00", endDateAndTime = "0001-01-01T00:00:00";
            DataTable dataTable = new DataTable();
            bool isValidDate;
            string dateFormat = "yyyy-MM-dd";

            if (!string.IsNullOrWhiteSpace(startDate))
            {
                isValidDate = IsValidDateFormat(startDate, dateFormat);
                if (isValidDate)
                {
                    startDateAndTime = startDate + "T00:00:00";
                }
                else
                {
                    message = "Invalid date format";
                    return dataTable;
                }
            }

            if (!string.IsNullOrWhiteSpace(endDate))
            {
                isValidDate = IsValidDateFormat(endDate, dateFormat);
                if (isValidDate)
                {
                    endDateAndTime = endDate + "T23:59:59";
                }
                else
                {
                    message = "Invalid date format";
                    return dataTable;
                }
            }

            TransactionData transactionData = new TransactionData();

            dataTable = transactionData.GetTransactionsByPeriod(startDateAndTime, endDateAndTime, out message);

            return dataTable;
        }
        #endregion

        #region IsValidDateFormat
        public bool IsValidDateFormat(string dateString, string format)
        {
            DateTime date;
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
        #endregion
    }
}
