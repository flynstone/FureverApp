using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Furever.Entities;
using Furever.Entities.Models;
using Furever.Repositories.Interfaces;

namespace Furever.Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        public AnimalRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _context.Animals
                .Include(c => c.Category)
                .Include(r => r.Refuge)
                .ToListAsync();
        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await _context.Animals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Animal> CreateAnimal(Animal animal)
        {
            _context.Add(animal);
            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task UpdateAnimal(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnimal(Animal animal)
        {
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
        }
    }
}
