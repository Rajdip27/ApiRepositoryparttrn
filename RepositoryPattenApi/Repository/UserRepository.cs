using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using RepositoryPattenApi.DatabaseContext;
using RepositoryPattenApi.Interfaces.Repository;
using RepositoryPattenApi.Models;

namespace RepositoryPattenApi.Repository
{
    public class UserRepository : CommonRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
