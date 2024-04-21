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
            using (SqlConnection conexionDB = new SqlConnection(connectionString))
            {
                using (SqlCommand comandoSql = new SqlCommand())
                {
                    comandoSql.CommandType = CommandType.StoredProcedure;
                    comandoSql.CommandText = "InsertTransaction";
                    comandoSql.Connection = conexionDB;

                    comandoSql.Parameters.AddWithValue("@CustomerId", transaction.CustomerId);
                    comandoSql.Parameters.AddWithValue("@TXNTypeId", transaction.TXNTypeId);
                    comandoSql.Parameters.AddWithValue("@Amount", transaction.Amount);
                    //comandoSql.Parameters.Add("@IdRecibo", SqlDbType.Int);
                    //comandoSql.Parameters["@IdRecibo"].Direction = ParameterDirection.Output;

                    conexionDB.Open();

                    comandoSql.ExecuteNonQuery();

                    message = "Ok";

                    //idRecibo = Convert.ToInt32(comandoSql.Parameters["@IdRecibo"].Value);

                }
            }
        }
        #endregion

        internal void GetTransactionsByPeriod(DateTime startDate, DateTime endDate, out string message)
        {

        }
    }
}