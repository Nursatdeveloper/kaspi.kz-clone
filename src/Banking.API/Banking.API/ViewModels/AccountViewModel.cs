namespace Banking.API.ViewModels
{
    public class AccountViewModel
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
    }
}
