using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webhoa.Configuration;
using webhoa.Services;
using webhoa.ViewModel;

namespace webhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanJWTController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TokenService _tokenService;
       
        private readonly RoleManager<IdentityRole> _roleManager;
        public TaiKhoanJWTController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            TokenService tockenService,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tockenService;
        }
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserDetails userDetails)
        {
            var userExists = await _userManager.FindByNameAsync(userDetails.UserName);
            if (userExists != null)

                return StatusCode(StatusCodes.Status500InternalServerError, new Model.Response { Status = " Error", Message = " User Đã có trong hệ thống" });

            var identityUser = new IdentityUser()
            {
                UserName = userDetails.UserName,
                Email = userDetails.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Model.Response { Status = "Error", Message = "có lỗi khi thạo user! kiểm tra và thử lại" });
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin)) ;
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User)) ;
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(identityUser, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(identityUser, UserRoles.User);
            }
            return Ok(new Model.Response { Status = "Success", Message = "User được tạo thành công !" });

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, credentials.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = _tokenService.GenerateToken(user, roles);

                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }
}
