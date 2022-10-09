using Banking.Core.Entities;

namespace Banking.API.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; init; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IIN { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? PhotoUrl { get; set; }
        public ICollection<AccountViewModel> Accounts { get; set; }
    }
}
