using Banking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Responses
{
    public class CreateUserResponse
    {
        public int UserId { get; set; }
        public User? CreatedUser { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
