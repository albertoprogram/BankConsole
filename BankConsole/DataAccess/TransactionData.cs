﻿using BankConsole.Entities;
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
        IConfiguration configuration;
        string connectionString;

        public TransactionData()
        {
            connectionString = configuration.GetConnectionString("SQLServer");
        }

        internal void SaveTransaction(Transaction transaction)
        {
            using (SqlConnection conexionDB = new SqlConnection(connectionString))
            {
                using (SqlCommand comandoSql = new SqlCommand())
                {
                    //comandoSql.CommandType = CommandType.StoredProcedure;
                    //comandoSql.CommandText = "Ins_Recibo";
                    //comandoSql.Connection = conexionDB;

                    //comandoSql.Parameters.AddWithValue("@RecibidoDe", txtRecibiDe.Text.Trim());
                    //comandoSql.Parameters.AddWithValue("@Monto", monto);
                    //comandoSql.Parameters.AddWithValue("@MontoLetras", txtCantidadLetras.Text.Trim());
                    //comandoSql.Parameters.AddWithValue("@Concepto", txtConcepto.Text.Trim());
                    //comandoSql.Parameters.AddWithValue("@Ciudad", cmbCiudad.Text.Trim());
                    //comandoSql.Parameters.AddWithValue("@Fecha", dtpFecha.Value);
                    //comandoSql.Parameters.Add("@IdRecibo", SqlDbType.Int);
                    //comandoSql.Parameters["@IdRecibo"].Direction = ParameterDirection.Output;

                    //conexionDB.Open();

                    //comandoSql.ExecuteNonQuery();

                    //idRecibo = Convert.ToInt32(comandoSql.Parameters["@IdRecibo"].Value);

                }
            }
        }
    }
}