using Apicursos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apicursos.Helpers;
using Microsoft.Extensions.Logging;
using GestaoCursos.Repositories;
using GestaoCursos.Controllers;
using GestaoCursos.Context;

namespace Apicursos.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _users;
        private readonly ILogger _logger;
        public AuthController(ILogger<AuthController> logger, IUsersService users)
        {
            _logger = logger;
            _users = users;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/v1/auth")]
        public async Task<IActionResult> Authentication([FromBody] User user)
        {
            try
            {
                var userExists = user;

                if (user == null)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                if (user.Password != user.Password)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });

                var token = JwtAuth.GenerateToken(userExists);

                return Ok(new
                {
                    Token = token,
                    Usuario = userExists
                });

            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }
    }
}
