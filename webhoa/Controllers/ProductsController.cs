using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webhoa.Configuration;
using webhoa.Model;
using webhoa.Repository;

namespace webhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IFlowerRepository _hoaRepo;

        public ProductsController(IFlowerRepository repo)
        {
            _hoaRepo = repo;
        }
        [HttpGet]
        //[Authorize(Roles = UserRoles.Admin)]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllHoa()
        {
            try
            {
                return Ok(await _hoaRepo.getAllHoasAsync());

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{MaSp}")]
        //[Authorize]
        public async Task<IActionResult> GetHoaById(int MaSp)
        {
            var flower = await _hoaRepo.getHoaAsync(MaSp);
            return flower == null ? NotFound() : Ok(flower);
         }
        [HttpPost]
        public async Task<IActionResult> AddNewFlower(HoaVM model)
        {
            try
            {
                var newflowerid =await _hoaRepo.AddHoaAsync(model);
                var flower = await _hoaRepo.getHoaAsync(newflowerid);
                return flower == null ? NotFound() : Ok(flower);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{MaSp}")]
        public async Task<IActionResult> Updateflower(int MaSp,[FromBody] HoaVM model)
        {
            if(MaSp != model.MaSp)
            {
                return NotFound();
            }
            await _hoaRepo.UpdateHoaAsync(MaSp, model);
            return Ok();

        }
        [HttpDelete("{MaSp}")]
       public async Task<IActionResult> Deleteflower([FromRoute] int MaSp)
        {
             await _hoaRepo.DeleteHoaAsync(MaSp);
            return Ok();
        }
    }
}
