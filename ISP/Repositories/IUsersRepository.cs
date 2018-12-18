using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISP.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<IEnumerable<Users>> GetByID(string username, string password);
        Task<IEnumerable<Users>> GetByID(int id);
        Task<int> Insert(Users user);
        void Delete(int id);
        void Update(Users item);
        void Save();
    }
}