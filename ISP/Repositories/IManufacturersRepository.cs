using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISP.Models
{
    public interface IManufacturersRepository
    {
        Task<IEnumerable<Manufacturers>> GetManufacturers();
        Task<IEnumerable<Manufacturers>> GetByID(int id);
        Task<int> Insert(Manufacturers manufacturer);
        void Delete(int id);
        void Update(Manufacturers manufacturer);
        void Save();
    }
}