using FluentValidation;
using MediatR;
using Pattern.Commands;
using Pattern.Models;
using Pattern.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pattern.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<User> _userValidator;

        public UpdateUserHandler(IUserRepository userRepository,IValidator<User> userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(request.Id);

            if (existingUser == null)
            {
                throw new Exception($"User with ID {request.Id} not found.");
            }

            existingUser.Name = request.Name;
            var validationResult = await _userValidator.ValidateAsync(existingUser, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var updatedUser = await _userRepository.UpdateUserAsync(existingUser);

            return updatedUser;
        }
    }
}
