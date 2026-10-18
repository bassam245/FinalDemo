using AutoMapper;
using FinalDemo.Dto;
using FinalDemo.Models;
using FinalDemo.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOffWork unitOffWork;
        private readonly IMapper mapper;

        public IConfiguration configuration;

        public AuthController(IUnitOffWork unitOffWork, IMapper mapper, IConfiguration configuration)
        {
            this.unitOffWork = unitOffWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await unitOffWork.users.GetAll();
            var validate = user.FirstOrDefault(s => s.Email == loginDto.Email && s.PasswordHash == loginDto.PasswordHash);
            if (validate == null) return Unauthorized();
            var clims = new[]
            {
              new  Claim(ClaimTypes.NameIdentifier,validate.Id.ToString()),
              new  Claim(ClaimTypes.Email,validate.Email),
              new  Claim(ClaimTypes.Role,validate.Role)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secretkey"]));
            var cerdnats = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken
            (
                 issuer: configuration["Jwt:Issure"],
                 audience: configuration["Jwt:Audiense"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cerdnats,
                claims: clims


            );
           
                var handeller = new JwtSecurityTokenHandler();
            var stringtoken = handeller.WriteToken(Token);
            return Ok(stringtoken);

        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = await unitOffWork.users.GetAll();
            var validate = user.FirstOrDefault(s => s.Email == registerDto.Email);
            if (validate != null) return BadRequest();

            var customer = mapper.Map<User>(registerDto);
            customer.Role = "Customer";
             await unitOffWork.users.Add(customer);
            unitOffWork.savechanges();
            return Created();

        }
    }
}
