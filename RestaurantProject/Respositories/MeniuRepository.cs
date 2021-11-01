using Microsoft.EntityFrameworkCore;
using RestaurantProject.Data;
using RestaurantProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject.Respositories
{
    public class MeniuRepository
    {
        private readonly DataContext _context;

        public MeniuRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Meniu>> GetAsync()
        {
            return await _context.Menius.OrderBy(p => p.Price).ToListAsync();
        }

        public async Task<Meniu> GetByIdAsync(int id)
        {
            return await _context.Menius.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(Meniu meniu)
        {
            _context.Add(meniu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Meniu meniu)
        {
            _context.Remove(meniu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Meniu meniu)
        {
            _context.Menius.Update(meniu);
            await _context.SaveChangesAsync();
        }
    }
}
