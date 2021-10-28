using RestaurantProject.Entities;
using RestaurantProject.Respositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantProject.Services
{
    public class MeniuService
    {
        private MeniuRepository _meniuRepository;
        public MeniuService(MeniuRepository meniuRepository)
        {
            _meniuRepository = meniuRepository;
        }

        public async Task<List<Meniu>> GetAllAsync()
        {
            return await _meniuRepository.GetAsync();
        }


        public async Task CreateAsync(Meniu meniu)
        {

            await _meniuRepository.CreateAsync(meniu);
        }

        public async Task<Meniu> GetByIdAsync(int id)
        {
            return await _meniuRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var meniu = await GetByIdAsync(id);
            await _meniuRepository.DeleteAsync(meniu);
        }

        public async Task UpdateAsync(Meniu meniu)
        {
            var existingMeniu = await _meniuRepository.GetByIdAsync(meniu.Id);
            if (existingMeniu != null)
            {
                existingMeniu.Title = meniu.Title;
                existingMeniu.Price = meniu.Price;
                existingMeniu.Weight = meniu.Weight;
                existingMeniu.Meat = meniu.Meat;
            }
            await _meniuRepository.UpdateAsync(existingMeniu);
        }
    }
}

