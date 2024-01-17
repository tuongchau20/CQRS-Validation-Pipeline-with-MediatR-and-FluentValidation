using MediatR;
using Pattern.Models;

namespace Pattern.Queries
{
    public class GetAllUserQuery :IRequest<List<User>>
    {
        public List<User> Users { get; set; }
    }
}
