using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Entities;
using RestaurantProject.Services;
using System.Threading.Tasks;

namespace RestaurantProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeniuController : ControllerBase
    {
        private readonly MeniuService _meniuService;

        public MeniuController(MeniuService meniuService)
        {
            _meniuService = meniuService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _meniuService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var meniu = await _meniuService.GetByIdAsync(id);
            return Ok(meniu);
        }


        [HttpPost]
        public async Task<IActionResult> Add(Meniu meniu)
        {
            await _meniuService.CreateAsync(meniu);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _meniuService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Meniu meniu)
        {
            await _meniuService.UpdateAsync(meniu);
            return NoContent();
        }
    }
}
