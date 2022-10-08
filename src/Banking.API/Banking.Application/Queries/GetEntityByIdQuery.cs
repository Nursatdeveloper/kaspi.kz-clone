using Banking.Application.Responses;
using MediatR;

namespace Banking.Application.Queries
{
    public class GetEntityByIdQuery<T, K> : IRequest<K>
    {
        public int Id { get; set; }
        public GetEntityByIdQuery(int id)
        {
            Id = id;
        }
    }
}
