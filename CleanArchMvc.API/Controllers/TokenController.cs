using CleanArch.Domain.Account;
using CleanArchMvc.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IAuthenticate _authentication;
        private IConfiguration _configuration;
        public TokenController(IAuthenticate authenticate,IConfiguration configuration)
        {
            _authentication = authenticate;
            _configuration = configuration; 
        }
 
        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginDto loginDto)
        {
            var userAuthenticate =await _authentication.AuthenticateAsync(loginDto.Email, loginDto.Password);
            if (userAuthenticate)
            {
                return GenerateToken(loginDto);
                //return Ok($"User {loginDto.Email} login successfully");
            }
            else
            {
                ModelState.AddModelError(String.Empty,"Invalid Login attempt.");
                return BadRequest(ModelState);
            }

        }
        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi =true)]
        //[Authorize]
        public async Task<ActionResult> CreateUser([FromBody] LoginDto loginDto)
        {
            var createUser = await _authentication.RegisterUserAsync(loginDto.Email, loginDto.Password);
            if (createUser)
            {
                return Ok($"User {loginDto.Email} was successfully");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        private UserToken GenerateToken(LoginDto loginDto)
        {
            //declarações do usuário
            var claims = new[] {
             new Claim("email",loginDto.Email),
             new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            //GERAR A CHAVE PRIMARIA PARA ASSINAR O TOKEN
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //GERAR A ASSINATURA DIGITAL
            var credentials = new SigningCredentials(privateKey,SecurityAlgorithms.HmacSha256);

            //definir tempo de expiracao
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _configuration["Jwt:Issuer"],
                //audiencia
                audience: _configuration["Jwt:Audience"],
                //claims
                claims:claims,
                //data de expiração
                expires: expiration,
                //assinatura digital
                signingCredentials:credentials
                
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
