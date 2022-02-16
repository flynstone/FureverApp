using System.Threading.Tasks;

namespace Furever.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAnimalRepository Animal { get; }
        ICategoryRepository Category { get; }
        IRefugeRepository Refuge { get; }
        Task SaveAsync();
        Task<bool> Complete();
    }
}
