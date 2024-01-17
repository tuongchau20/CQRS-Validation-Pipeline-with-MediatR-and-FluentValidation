using MediatR;
using Pattern.Models;

namespace Pattern.Queries
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
