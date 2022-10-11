using Banking.Application.Queries;
using Banking.Application.Responses;
using Banking.Core.Entities;
using Banking.Infrastructure.Repositories;
using Banking.Infrastructure.Repositories.Base;
using MediatR;

namespace Banking.Application.Handlers.QueryHandlers
{
    public class DeleteEntityHandler<T> : IRequestHandler<DeleteEntityQuery<T>, DeletedResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteEntityHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<DeletedResponse> Handle(DeleteEntityQuery<T> request, CancellationToken cancellationToken)
        {
            Type entityType = typeof(T);
            if(entityType.Equals(typeof(User)))
            {
                bool isSuccessfullyDeleted = await _userRepository.Delete(request.Id);
                if (isSuccessfullyDeleted)
                {
                    return new DeletedResponse(true, "Deleted successfully");
                }
                return new DeletedResponse(false, "Delete failed!");
            }
            return new DeletedResponse(false, "Delete failed!");
        }
    }
}
