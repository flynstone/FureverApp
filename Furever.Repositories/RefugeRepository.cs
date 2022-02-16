using Furever.Entities;
using Furever.Entities.Models;
using Furever.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furever.Repositories
{
    public class RefugeRepository : RepositoryBase<Refuge>, IRefugeRepository
    {
        public RefugeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Refuge>> GetRefuges()
        {
            return await _context.Refuges.ToListAsync();
        }
        public async Task<Refuge> GetRefuge(int id)
        {
            return await _context.Refuges.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Refuge> CreateRefuge(Refuge refuge)
        {
            _context.Add(refuge);
            await _context.SaveChangesAsync();
            return refuge;
        }
        public async Task UpdateRefuge(Refuge refuge)
        {
            _context.Refuges.Update(refuge);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRefuge(Refuge refuge)
        {
            _context.Refuges.Remove(refuge);
            await _context.SaveChangesAsync();
        }

    }
}
