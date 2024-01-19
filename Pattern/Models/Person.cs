using FluentValidation;

namespace Pattern.Models
{
    public class Person:IInformationRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}
