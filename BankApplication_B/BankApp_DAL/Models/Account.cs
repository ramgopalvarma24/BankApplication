using System;
using System.Collections.Generic;

namespace BankApp_DAL.Models
{
    public partial class Account
    {
        public int AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public decimal? Balance { get; set; }
    }
}
