using MediatR;
using Pattern.Models;

namespace Pattern.Commands
{
    public class CreateInfoCommand : IRequest<string>
    {
        public string Name { get; set; }
        public int Age { get; set; }    
    }
}
