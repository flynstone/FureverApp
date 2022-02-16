using Furever.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furever.Repositories.Interfaces
{
    public interface IRefugeRepository
    {
        Task<IEnumerable<Refuge>> GetRefuges();
        Task<Refuge> GetRefuge(int id);
        Task<Refuge> CreateRefuge(Refuge refuge);
        Task UpdateRefuge(Refuge refuge);
        Task DeleteRefuge(Refuge refuge);
    }
}
