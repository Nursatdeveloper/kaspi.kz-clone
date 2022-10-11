using Banking.Application.Responses;
using MediatR;

namespace Banking.Application.Queries
{
    public class DeleteEntityQuery<T> : IRequest<DeletedResponse>
    {
        public int Id { get; set; }
        public DeleteEntityQuery(int id)
        {
            Id = id;
        }
    }
}
