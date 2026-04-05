using emlakPortali_APİ.DTOs;
using emlakPortali_APİ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace emlakPortali_APİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePicture = "default-profile.png"
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return Ok(new { Message = "User Created Successfully" });

            return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = GenerateJwtToken(user);
                return Ok(new UserDto { Id = user.Id, UserName = user.UserName, Token = token });
            }

            return Unauthorized();
        }
        [Authorize]
        [HttpGet("Users")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.Select(u => new
            {
                u.Id,
                u.FirstName,
                u.LastName,
                u.Email,
                u.UserName
            }).ToList();

            return Ok(users);
        }
        private string GenerateJwtToken(AppUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Email, user.Email)
    };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        
          }

        [Authorize]
        [HttpGet("MyProfile")]
        public async Task<IActionResult> GetMyProfile()
        {
            try
            {
                // Biletin (Token) içindeki tüm verileri okuyup listeleyelim
                var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

                // 1. İhtimal: ID standart NameIdentifier içinde mi?
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // 2. İhtimal: Belki token oluştururken "Name" içine koyduk?
                if (string.IsNullOrEmpty(userId))
                    userId = User.FindFirstValue(ClaimTypes.Name);

                // Eğer bilette hiçbir şey bulamazsa, biletin içindekileri ekrana yazdırsın!
                if (string.IsNullOrEmpty(userId))
                    return BadRequest("HATA: Biletin içinde kimlik bulamadım! Biletin içi şöyle: " + System.Text.Json.JsonSerializer.Serialize(claims));

                // Kimliği bulduysa önce ID olarak arasın
                var user = await _userManager.FindByIdAsync(userId);

                // Belki biletin içine ID yerine Kullanıcı Adı (UserName) yazdık? Bir de öyle arasın!
                if (user == null)
                    user = await _userManager.FindByNameAsync(userId);

                // Hala bulamadıysa, ekrana tam olarak NE ARADIĞINI yazdırsın!
                if (user == null)
                    return NotFound($"HATA: Veritabanında şu bilgiyi aradım ama bulamadım: '{userId}'");

                // Bulduysa nihayet veriyi göndersin
                return Ok(new
                {
                    firstName = user.FirstName ?? "İsimsiz",
                    lastName = user.LastName ?? "Kullanıcı",
                    email = user.Email
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu Hatası: " + ex.Message);
            }

        }
        [Authorize]
        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto model)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue(ClaimTypes.Name);
                if (string.IsNullOrEmpty(userId)) return Unauthorized("Bilette kimlik bulunamadı.");

                var user = await _userManager.FindByIdAsync(userId) ?? await _userManager.FindByNameAsync(userId);
                if (user == null) return NotFound("Kullanıcı bulunamadı.");
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return Ok(new { message = "Profil başarıyla güncellendi!" });
                else
                    return BadRequest("Güncelleme başarısız oldu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu Hatası: " + ex.Message);
            }
        }
        [Authorize]
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue(ClaimTypes.Name);
            var user = await _userManager.FindByIdAsync(userId) ?? await _userManager.FindByNameAsync(userId);

            if (user == null) return NotFound("Kullanıcı bulunamadı.");

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
                return Ok(new { message = "Şifreniz başarıyla değiştirildi!" });
            else
                return BadRequest("Mevcut şifrenizi yanlış girdiniz veya yeni şifreniz kurallara uymuyor.");
        }
        [Authorize]
        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue(ClaimTypes.Name);
            var user = await _userManager.FindByIdAsync(userId) ?? await _userManager.FindByNameAsync(userId);

            if (user == null) return NotFound("Kullanıcı zaten yok.");

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return Ok(new { message = "Hesabınız başarıyla silindi." });
            else
                return BadRequest("Hesap silinirken bir hata oluştu.");
        }
    }
    public class UpdateProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}