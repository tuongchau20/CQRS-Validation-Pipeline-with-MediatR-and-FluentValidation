using FluentValidation;
using Microsoft.JSInterop.Implementation;
using Pattern.Commands;
using System.ComponentModel.DataAnnotations;

namespace Pattern.Models
{
    public class User: IInformationRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }    
    }
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(person => person.Age).GreaterThan(0).WithMessage("Tuổi phải lớn hơn 0");
        }
    }
}
