using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiSeriesAlexExam.Models;
using WebApiSeriesAlexExam.Repositories;
using WebApiSeriesAlexExam.Token;

namespace WebApiSeriesAlexExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        SeriesRepository repository;
        HelperToken helper;
        public AuthController(SeriesRepository repo , IConfiguration  configuration)
        {
            this.helper = new HelperToken(configuration);
            this.repository = repo;
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {
            UsuariosAzure usuario =
                this.repository.Existe(model.UserName
                , int.Parse(model.Password));
            if (usuario != null)
            {
               
                Claim[] claims = new[]
                {
                    new Claim("UserData",
                    JsonConvert.SerializeObject(usuario))
                };

                JwtSecurityToken token = new JwtSecurityToken
                    (
                     issuer: helper.Issuer
                     , audience: helper.Audience
                     , claims: claims
                     , expires: DateTime.UtcNow.AddMinutes(10)
                     , notBefore: DateTime.UtcNow
                     , signingCredentials:
new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256)
                    );
                //DEVOLVEMOS UNA RESPUESTA AFIRMATIVA
                //CON SU TOKEN
                return Ok(
                    new
                    {
                        response =
                        new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
            else
            {
                return Unauthorized();
            }
        }



    }
}
