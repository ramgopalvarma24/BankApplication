using System;
using System.Collections.Generic;

namespace BankApp_DAL.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string? FromAccount { get; set; }
        public string? ToAccount { get; set; }
        public DateTime? TransactionTime { get; set; }
        public decimal? AmountDebited { get; set; }
        public decimal? FromAccountBalance { get; set; }
        public decimal? ToAccountBalance { get; set; }
        public string? DetailsLink { get; set; }
    }
}
