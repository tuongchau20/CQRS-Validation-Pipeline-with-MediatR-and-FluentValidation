using FluentValidation;
using MediatR;
using Pattern.Models;

namespace Pattern.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    
}
