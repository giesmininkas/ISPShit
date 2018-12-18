using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using ISP.Models;
using ISP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ISP.Controllers
{
    [Route("api/users")]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class UsersController : Controller
    {
        private IUsersRepository _usersRepository;
        
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _usersRepository.GetUsers();
        }

        public class pair
        {
            public string username { set; get; }
            public string password { set; get; }
        }
        
        [HttpPost("login")]
        public async Task<IEnumerable<Users>> GetUsers([FromBody] pair p)
        {
            return await _usersRepository.GetByID(p.username, p.password);
        }

        /*public class ItemRequest
        {
            public int id { set; get; }
            public string name { set; get; }
            public string description { set; get; }
            public double price { set; get; }
            public string category { set; get; }
            public string manufacturer { set; get; }

        }*/
        
        [HttpPost("register")]
        public async Task<Users> Create([FromBody] Users item)
        {
            int id = await _usersRepository.Insert(item);
            return _usersRepository.GetByID(id).Result.First();
            
            //int id = await _usersRepository.Insert(new Items(){Name = item.name, Description = item.description, Price = item.price});
            //return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _usersRepository.Delete(id); 
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Users item)
        {
            _usersRepository.Update(item);
            return Ok();
        }
    }
}