using Banking.Application.Helpers;
using Banking.Application.Responses;
using Banking.Core.Entities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands
{
    [DataContract]
    public class CreateUserCommand : IRequest<CreatedResponse<User>>
    {
        [DataMember]
        public string FirstName { get; init; }
        [DataMember]
        public string LastName { get; init; }
        [DataMember]
        public string IIN { get; init; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public string Email { get; init; }
        [DataMember]
        public string Password { get; init; }
        [DataMember]
        public string Telephone { get; init; }
        [DataMember]
        public string QuickAccessCode { get; init; }
    }
}
