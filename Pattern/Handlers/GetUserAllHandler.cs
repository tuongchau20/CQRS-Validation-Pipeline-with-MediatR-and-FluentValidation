using MediatR;
using Pattern.Models;
using Pattern.Queries;
using Pattern.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pattern.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            

            var user = await _userRepository.GetUserByIdAsync(request.Id);

            if (user == null)
            {
              
                throw new Exception($"User with ID {request.Id} not found.");
            }

            return user;
        }
    }
}
