using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public string? Currency { get; set; }
        public string? BankName { get; set; }
        public string? IBAN { get; set; }
        public string? BIC { get; set; }
        public string? IIN { get; set; }
        public string? Customer { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
