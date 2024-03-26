using BankConsole.Presentation;
using Microsoft.Extensions.Configuration;

namespace BankConsole
{
    internal class Program
    {
        #region Variables
        public static IConfiguration Configuration;
        #endregion

        #region Main
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            TransactionFrontEnd transactionFrontEnd = new TransactionFrontEnd();

            transactionFrontEnd.RequestTransactionData();
        }
        #endregion
    }
}
