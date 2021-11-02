using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Dto;
using RestaurantProject.Services;
using System.Threading.Tasks;

namespace RestaurantProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _restaurantService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var restaurant = await _restaurantService.GetByIdAsync(id);
            return Ok(restaurant);
        }

        [HttpGet]
        [Route("RestaurantsbyMeniu/{meniuId}")]
        public async Task<ActionResult> GetByMeniuId(int meniuId)
        {
            var restaurant = await _restaurantService.GetByMeniuIdAsync(meniuId);
            return Ok(restaurant);
        }


        [HttpPost]
        public async Task<IActionResult> Add(RestaurantCreateEditDto restaurant)
        {
            var result = await _restaurantService.CreateAsync(restaurant);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _restaurantService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(RestaurantCreateEditDto restaurant)
        {
            await _restaurantService.UpdateAsync(restaurant);
            return NoContent();
        }
    }
}

