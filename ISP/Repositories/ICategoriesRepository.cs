using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISP.Models
{
    public interface ICategoriesRepository : IDisposable
    {
        Task<IEnumerable<ItemCategories>> GetCategories();
        ItemCategories GetByID(int id);
        void Insert(ItemCategories category);
        void Delete(int id);
        void Update(ItemCategories category);
        void Save();
    }
}