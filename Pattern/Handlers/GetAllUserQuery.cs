using MediatR;
using Pattern.Models;
using Pattern.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pattern.Data;

namespace Pattern.Handlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly UserDbContext _dbContext;

        public GetAllUserHandler(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users.ToListAsync(cancellationToken);

            return users;
        }
    }
}
