using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ISP.Models;
//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using Microsoft.Extensions.Caching.Memory;

namespace ISP.Controllers
{
    [Route("api/items")]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ItemsController : Controller
    {
        // GET
        /*public IActionResult Index()
        {
            return
            View();
        }*/

        private IItemsRepository _itemsRepository;
        
        
        public ItemsController(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Items>> GetItems()
        {
            return await _itemsRepository.GetItems();
        } 
        
        [HttpGet("{id}")]
        public async Task<IEnumerable<Items>> GetItems(int id)
        {
            return await _itemsRepository.GetByID(id);
        }

        public class ItemRequest
        {
            public int id { set; get; }
            public string name { set; get; }
            public string description { set; get; }
            public double price { set; get; }
            public string category { set; get; }
            public string manufacturer { set; get; }

        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemRequest item)
        {
            //int manufId = _
            
            int id = await _itemsRepository.Insert(new Items(){Name = item.name, Description = item.description, Price = item.price});
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _itemsRepository.Delete(id); 
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] ItemRequest item)
        {
            _itemsRepository.Update(new Items(){Id = item.id, Name = item.name, Description = item.description, Price = item.price});
            return Ok();
        }
    }
}