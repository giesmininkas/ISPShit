using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ISP.Models
{
    public class ItemsRepository : IItemsRepository
    {
        private ISPContext IspContext;

        public ItemsRepository(ISPContext ispContext)
        {
            IspContext = ispContext;
        }

        public async Task<IEnumerable<Items>> GetItems()
        {
            return await (from item in IspContext.Items
                join manuf in IspContext.Manufacturers on item.ManufacturerId equals manuf.Id
                join cat in IspContext.ItemCategories on item.CategoryId equals cat.Id
                select new Items()
                {
                    Category = cat, CategoryId = cat.Id, Description = item.Description, Height = item.Height,
                    Id = item.Id, Manufacturer = manuf, ManufacturerId = manuf.Id, Name = item.Name, Price = item.Price,
                    Width = item.Width
                }).ToListAsync();
            //ToListAsync();
            

            /*return await IspContext.Items
                .Include(x => x.Category)
                .Include(x => x.Manufacturer)
                .Select(x => x)
                .ToListAsync();*/
        }

        public async Task<IEnumerable<Items>> GetByID(int id)
        {
            return await (from item in IspContext.Items
                join manuf in IspContext.Manufacturers on item.ManufacturerId equals manuf.Id
                join cat in IspContext.ItemCategories on item.CategoryId equals cat.Id
                where item.Id == id
                select new Items()
                {
                    Category = cat, CategoryId = cat.Id, Description = item.Description, Height = item.Height,
                    Id = item.Id, Manufacturer = manuf, ManufacturerId = manuf.Id, Name = item.Name, Price = item.Price,
                    Width = item.Width
                }).ToListAsync();
        }

        public async Task<int> Insert(Items item)
        {
            item.ManufacturerId = 1;
            item.CategoryId = 3;
            item.Width = 1;
            item.Height = 1;
            
            IspContext.Add(item);
            return await IspContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            IspContext.Items.Remove(GetByID(id).Result.First());
            await IspContext.SaveChangesAsync();
        }

        public async void Update(Items item)
        {
            IspContext.Items.Update(item);
            await IspContext.SaveChangesAsync();
            //throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}