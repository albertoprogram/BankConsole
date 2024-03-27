using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole.Entities
{
    internal class Transaction
    {
        #region Properties
        public Guid Id { get; set; }
        public string? CustomerId { get; set; }
        public string? TXNId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TXNDate { get; set; }
        #endregion
    }
}
