using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http.Results;
using ISP.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace ISP.Models
{
    public class UsersRepository : IUsersRepository
    {
        private ISPContext IspContext;

        public UsersRepository(ISPContext ispContext)
        {
            IspContext = ispContext;
        }
        
        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await (from user in IspContext.Users
                select user).ToListAsync();
            
        }

        public async Task<IEnumerable<Users>> GetByID(string username, string password)
        {
            return await (from user in IspContext.Users
                where user.Username == username && user.Password == password
                select user).ToListAsync();
        }

        public async Task<int> Insert(Users user)
        {
            IspContext.Add(user);
            return await IspContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            IspContext.Users.Remove(GetByID(id).Result.First());
            await IspContext.SaveChangesAsync();
        }

        public async void Update(Users item)
        {
            IspContext.Users.Update(item);
            await IspContext.SaveChangesAsync();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}