using System.ComponentModel.DataAnnotations;

namespace Banking.Core.Entities
{
    public class User
    {
        
        public int Id { get; init; }
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [MaxLength(12)]
        //[RegularExpression(@"^\d+$")]
        public string? IIN { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Telephone { get; set; }
        public string? QuickAccessCode { get; set; }
        public string? PhotoUrl { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
