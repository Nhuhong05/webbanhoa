using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webhoa.Configuration;
using webhoa.Model;
using webhoa.Repository;
using webhoa.Services;
using webhoa.ViewModel;

namespace webhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHoaController : ControllerBase
    {
       
        private readonly ILoaiHoaRepository _loaihoaRepo;

        public LoaiHoaController(ILoaiHoaRepository loaihoa)
        {
            _loaihoaRepo = loaihoa;
        }
        [HttpGet]
        //[Authorize(Roles = UserRoles.Admin)]
        //[Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> GetAllLoaiHoa()
        {
            try
            {
                return Ok(await _loaihoaRepo.getAllLoaiHoasAsync());

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{MaLoai}")]
       
        //[Authorize]
        public async Task<IActionResult> GetLoaiHoaById(int MaLoai)
        {
            var flower = await _loaihoaRepo.getLoaiHoaAsync(MaLoai);
            return flower == null ? NotFound() : Ok(flower);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewLoaiFlower(LoaiHoaVM model)
        {
            try
            {
                var newflowerid = await _loaihoaRepo.AddLoaiHoaAsync(model);
                var flower = await _loaihoaRepo.getLoaiHoaAsync(newflowerid);
                return flower == null ? NotFound() : Ok(flower);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{MaLoai}")]
        public async Task<IActionResult> UpdateLoaiflower(int MaLoai, [FromBody] LoaiHoaVM model)
        {
            if (MaLoai != model.MaLoai)
            {
                return NotFound();
            }
            await _loaihoaRepo.UpdateLoaiHoaAsync(MaLoai, model);
            return Ok();

        }
        [HttpDelete("{MaLoai}")]
        public async Task<IActionResult> DeleteLoaiflower([FromRoute] int MaLoai)
        {
            await _loaihoaRepo.DeleteLoaiHoaAsync(MaLoai);
            return Ok();
        }
    }
}
