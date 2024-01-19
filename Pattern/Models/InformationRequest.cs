using FluentValidation;
using MediatR;

namespace Pattern.Models
{
    public class InformationRequest : IRequest<string>
    {
        public List<IInformationRequest> Information { get; } = new List<IInformationRequest>();
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }    
    }
    public class InformationRequestValidator : AbstractValidator<InformationRequest>
    {
        public InformationRequestValidator()
        {
            RuleForEach(x => x.Information).SetInheritanceValidator(v =>
            {
                v.Add<Person>(new PersonValidator());
                v.Add<User>(new UserValidator());
            });
        }
    }

}
