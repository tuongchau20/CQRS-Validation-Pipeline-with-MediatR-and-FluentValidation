using FluentValidation;
using MediatR;
using Pattern.Commands;
using Pattern.Models;

namespace Pattern.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public UpdateUserCommand(string name)
        {
            Name = name;
        }

        public UpdateUserCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; } 
        public string Name { get; set; }
    }
}

