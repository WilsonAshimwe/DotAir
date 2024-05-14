using Be.Khunly.Security;
using DotAir.API.DTO;
using DotAir.BLL.Services;
using DotAir.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotAir.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController(SecurityService _securityService, JwtManager _jwtManager) : ControllerBase
    {
        [HttpPost]
        public IActionResult LoginM([FromBody] LoginDTO dto)
        {
            try
            {
                Login l = _securityService.Login(dto.Username, dto.Password);
                string token = _jwtManager.CreateToken(l.Email, l.Id.ToString(), l.Email, l.Role);
                return Ok(new { Token = token });
            }
            catch (ValidationException)
            {
                return BadRequest("Invalid Credentials");
            }
        }
    }
}
