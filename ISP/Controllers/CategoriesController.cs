using System.Collections.Generic;
using System.Threading.Tasks;
using ISP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISP.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        // GET
        /*public IActionResult Index()
        {
            //return
            //View();
        }*/

        private ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemCategories>> GetCategories()
        {
            return await _categoriesRepository.GetCategories();
        } 
    }
}