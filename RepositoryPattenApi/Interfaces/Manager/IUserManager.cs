using EF.Core.Repository.Interface.Manager;
using RepositoryPattenApi.Models;

namespace RepositoryPattenApi.Interfaces.Manager
{
    public interface IUserManager:ICommonManager<User>
    {
        User GetById(int id);
        ICollection<User> UserSarch(string text);
        ICollection<User> PagingUser(int page, int pageSize);

    }
}
