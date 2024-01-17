using MediatR;
using Pattern.Data;
using Pattern.Models;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Pattern.Commands;

namespace Pattern.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly UserDbContext _dbContext;
        private readonly IValidator<User> _userValidator;

        public CreateUserHandler(UserDbContext dbContext, IValidator<User> userValidator)
        {
            _dbContext = dbContext;
            _userValidator = userValidator;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name
            };

            var validationResult = await _userValidator.ValidateAsync(user, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
