using Banking.Application.Responses;
using Banking.Core.Entities;
using MediatR;
using System.Runtime.Serialization;

namespace Banking.Application.Commands
{
    [DataContract]
    public class CreateAccountCommand : IRequest<CreateResponse<Account>>
    {
        [DataMember]
        public int UserId { get; init; }
        [DataMember]
        public string? Currency { get; init; }
        [DataMember]
        public string? Type { get; set; }

    }
}
