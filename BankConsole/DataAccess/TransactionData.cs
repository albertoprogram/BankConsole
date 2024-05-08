using BankConsole.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole.DataAccess
{
    internal class TransactionData
    {
        #region Variables
        private readonly string? connectionString;
        #endregion

        #region Constructors
        public TransactionData()
        {
            if (Program.Configuration != null)
            {
                connectionString = Program.Configuration.GetConnectionString("SQLServer");
            }
        }
        #endregion

        #region SaveTransaction
        internal void SaveTransaction(Transaction transaction, out string message)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertTransaction";
                    command.Connection = connection;

                    command.Parameters.AddWithValue("@CustomerId", transaction.CustomerId);
                    command.Parameters.AddWithValue("@TXNTypeId", transaction.TXNTypeId);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    //command.Parameters.Add("@IdRecibo", SqlDbType.Int);
                    //command.Parameters["@IdRecibo"].Direction = ParameterDirection.Output;

                    connection.Open();

                    command.ExecuteNonQuery();

                    message = "Ok";

                    //idRecibo = Convert.ToInt32(command.Parameters["@IdRecibo"].Value);

                }
            }
        }
        #endregion

        #region GetTransactionsByPeriod
        internal DataTable GetTransactionsByPeriod(string startDate, string endDate, out string message)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetTransactionsByPeriod", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(dataTable);

                    message = "Ok";
                }
            }

            return dataTable;
        }
        #endregion
    }
}