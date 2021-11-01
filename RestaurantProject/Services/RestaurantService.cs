using RestaurantProject.Dto;
using RestaurantProject.Entities;
using RestaurantProject.Respositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantProject.Services
{
    public class RestaurantService
    {
        private RestaurantRepository _restaurantRepository;
        public RestaurantService(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _restaurantRepository.GetAsync();
        }


        public async Task CreateAsync(RestaurantCreateEditDto restaurant)
        {
            var restaurantEntity = new Restaurant()
            {
                Id = restaurant.Id,
                Title = restaurant.Title,
                Customers = restaurant.Customers,
                Employees = restaurant.Employees,
                MeniuId = restaurant.MeniuId
            };

            await _restaurantRepository.CreateAsync(restaurantEntity);
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _restaurantRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var restaurant = await GetByIdAsync(id);
            await _restaurantRepository.DeleteAsync(restaurant);
        }

        public async Task UpdateAsync(RestaurantCreateEditDto restaurant)
        {
            var existingRestaurant = await _restaurantRepository.GetByIdAsync(restaurant.Id);
            if (existingRestaurant != null)
            {
                existingRestaurant.Title = restaurant.Title;
                existingRestaurant.Customers = restaurant.Customers;
                existingRestaurant.Employees = restaurant.Employees;
                existingRestaurant.MeniuId = restaurant.MeniuId;
            }
            await _restaurantRepository.UpdateAsync(existingRestaurant);
        }
    }
}
