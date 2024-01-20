//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using webhoa.Repository;
//using webhoa.ViewModel;

//namespace webhoa.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DonHangController : ControllerBase
//    {
//        private readonly IdonhangRepositorycs _Repo;

//        public DonHangController(IdonhangRepositorycs dh)
//        {
//            _Repo = dh;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAllDH()
//        {
//            try
//            {
//                return Ok(await _Repo.getAllDHAsync());

//            }
//            catch
//            {
//                return BadRequest();
//            }
//        }
//        [HttpGet("{MaDh}")]
//        public async Task<IActionResult> GetDHById(int MaDh)
//        {
//            var flower = await _Repo.getDHAsync(MaDh);
//            return flower == null ? NotFound() : Ok(flower);
//        }
//        [HttpPost]
//        public async Task<IActionResult> AddNewDHFlower(DonHangVM model)
//        {
//            try
//            {
//                var newdh = await _Repo.AddDHAsync(model);
//                var dh = await _Repo.getDHAsync(newdh);
//                return dh == null ? NotFound() : Ok(dh);
//            }
//            catch
//            {
//                return BadRequest();
//            }
//        }
//        [HttpPut("{MaDh}")]
//        public async Task<IActionResult> UpdateL(int MaDh, [FromBody] DonHangVM model)
//        {
//            if (MaDh != model.MaDh)
//            {
//                return NotFound();
//            }
//            await _Repo.UpdateDHAsync(MaDh, model);
//            return Ok();

//        }
//        [HttpDelete("{MaDh}")]
//        public async Task<IActionResult> DeleteLoaiflower([FromRoute] int MaDh)
//        {
//            await _Repo.DeleteDHAsync(MaDh);
//            return Ok();
//        }
//    }
//}
