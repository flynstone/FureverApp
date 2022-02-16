using System.Collections.Generic;
using System.Threading.Tasks;
using Furever.Entities.Models;

namespace Furever.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal> GetAnimal(int id);
        Task<Animal> CreateAnimal(Animal animal);
        Task UpdateAnimal(Animal animal);
        Task DeleteAnimal(Animal animal);
    }
}
