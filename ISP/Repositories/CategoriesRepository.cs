using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ISP.Models
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private ISPContext IspContext;

        public CategoriesRepository(ISPContext context)
        {
            IspContext = context;
        }
        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ItemCategories>> GetCategories()
        {
            return await IspContext.ItemCategories.Select(x => x).ToListAsync();
        }

        public ItemCategories GetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(ItemCategories category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ItemCategories category)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}