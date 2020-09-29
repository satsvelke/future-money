using System;
using System.Text.Json.Serialization;

namespace Api.Logic.ViewModel
{
    public class BankView
    {
        public Guid BankId { get; set; }
        public string BankName { get; set; }
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
