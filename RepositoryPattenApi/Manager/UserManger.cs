using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using RepositoryPattenApi.DatabaseContext;
using RepositoryPattenApi.Interfaces.Manager;
using RepositoryPattenApi.Models;
using RepositoryPattenApi.Repository;

namespace RepositoryPattenApi.Manager
{
    public class UserManger : CommonManager<User>, IUserManager
    {
        public UserManger(ApplicationDbContext dbContext) : base(new UserRepository(dbContext))
        {

        }

        public ICollection<User> GetAddressSarch(string Address)
        {
            return Get(c => c.Address.ToLower().Contains(Address));
        }

        public User GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }

        public ICollection<User> PagingUser(int page, int pageSize)
        {
            if (page <= 1)
            {
                page = 1;
            }
            int Total=page*pageSize;
            return GetAll().Skip(Total).Take(pageSize).ToList();
        }

        public ICollection<User> UserSarch(string text)
        {
            return Get(c=>c.Name.ToLower().Contains(text)||c.Address.ToLower().Contains(text));
        }
    }
}
