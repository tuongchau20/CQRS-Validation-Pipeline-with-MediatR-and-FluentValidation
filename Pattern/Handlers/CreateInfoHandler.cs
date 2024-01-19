using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.VisualBasic;
using Pattern.Data;
using Pattern.Models;

namespace Pattern.Handlers
{
    public class CreateInfoHandler : IRequestHandler<InformationRequest, string>
    {
        private readonly UserDbContext _dbContext;
        private readonly IValidator<InformationRequest> _informationValidator;

        public CreateInfoHandler(UserDbContext dbContext, IValidator<InformationRequest> informationValidator)
        {
            _dbContext = dbContext;
            _informationValidator = informationValidator;
        }

        public async Task<string> Handle(InformationRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _informationValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var information = new InformationRequest
            {
                Name = request.Name,
                Age = request.Age
            };

            _dbContext.Information.Add(information);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return "Success";
        }
    }
}
