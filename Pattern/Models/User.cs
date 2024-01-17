using FluentValidation;
using Microsoft.JSInterop.Implementation;
using Pattern.Commands;
using System.ComponentModel.DataAnnotations;

namespace Pattern.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(5);
        }
    }
}
