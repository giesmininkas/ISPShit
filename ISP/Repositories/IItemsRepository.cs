using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISP.Models
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Items>> GetItems();
        Task<IEnumerable<Items>> GetByID(int id);
        Task<int> Insert(Items item);
        void Delete(int id);
        void Update(Items item);
        void Save();
    }
}