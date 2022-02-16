using System.Threading.Tasks;
using Furever.Entities;
using Furever.Repositories.Interfaces;

namespace Furever.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IAnimalRepository _animalRepository;
        private ICategoryRepository _categoryRepository;
        private IRefugeRepository _refugeRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAnimalRepository Animal
        {
            get
            {
                if (_animalRepository == null)
                    _animalRepository = new AnimalRepository(_context);
                return _animalRepository;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public IRefugeRepository Refuge
        {
            get
            {
                if (_refugeRepository == null)
                    _refugeRepository = new RefugeRepository(_context);
                return _refugeRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
