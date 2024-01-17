using MediatR;
using Pattern.Commands;
using Pattern.Repositories;

namespace Pattern.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(request.Id);

            if (existingUser == null)
            {
                throw new Exception($"User with ID {request.Id} not found.");
            }

            var isDeleted = await _userRepository.DeleteUserAsync(request.Id);

            return isDeleted;
        }
    }
}
