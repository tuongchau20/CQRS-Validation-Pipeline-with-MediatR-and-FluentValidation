using FluentValidation;
using MediatR;

namespace Pattern.Helper
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators
                .Select(v => v.ValidateAsync(context, cancellationToken)));
            var fail = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (fail.Count != 0)
            {
                throw new ValidationException(fail);
            }
            return await next();
        }
    }

 
}