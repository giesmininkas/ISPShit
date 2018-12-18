using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ISP.Models
{
    public class ManufacturersRepository : IManufacturersRepository
    {
        private ISPContext IspContext;

        public ManufacturersRepository(ISPContext ispContext)
        {
            IspContext = ispContext;
        }

        public async Task<IEnumerable<Manufacturers>> GetManufacturers()
        {
            return await (from manuf in IspContext.Manufacturers
                select manuf).ToListAsync();
            //ToListAsync();


            /*return await IspContext.Items
                .Include(x => x.Category)
                .Include(x => x.Manufacturer)
                .Select(x => x)
                .ToListAsync();*/

        }

        public async Task<IEnumerable<Manufacturers>> GetByID(int id)
        {
            return new List<Manufacturers>() {IspContext.Find<Manufacturers>(id)};
            
            return await (from manuf in IspContext.Manufacturers
                where id == manuf.Id
                select manuf).ToListAsync();
            /*return await (from item in IspContext.Items
                join manuf in IspContext.Manufacturers on item.ManufacturerId equals manuf.Id
                join cat in IspContext.ItemCategories on item.CategoryId equals cat.Id
                where item.Id == id
                select new Items()
                {
                    Category = cat, CategoryId = cat.Id, Description = item.Description, Height = item.Height,
                    Id = item.Id, Manufacturer = manuf, ManufacturerId = manuf.Id, Name = item.Name, Price = item.Price,
                    Width = item.Width
                }).ToListAsync();*/
        }

        public async Task<int> Insert(Manufacturers manufacturer)
        {
            /*item.ManufacturerId = 1;
            item.CategoryId = 3;
            item.Width = 1;
            item.Height = 1;*/
            
            IspContext.Add(manufacturer);
            return await IspContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            IspContext.Manufacturers.Remove(GetByID(id).Result.First());
            await IspContext.SaveChangesAsync();
        }

        public async void Update(Manufacturers item)
        {
            
            //IspContext.Items.Update(item);
            await IspContext.SaveChangesAsync();
            //throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}