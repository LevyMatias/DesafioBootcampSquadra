using Apicursos.Models;
using GestaoCursos.Models;
using GestaoCursos.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apicursos.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _users;
        private readonly ILogger _logger;
        public UserController(ILogger<UserController> logger, IUsersService users)
        {
            _logger = logger;
            _users = users;
        }

        [HttpPost]
        public IActionResult AddCourses([FromBody] User users)
        {
            return Ok(_users.AddUsers(users));
        }
        [HttpGet]
        [Route("/api/v1/user/allusers")]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            return Ok("Olá " + User.Identity.Name + " rota aberta a todos os colaboradores.");
        }


        [HttpGet]
        [Route("/api/v1/user/manager")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetManager()
        {
            return Ok("Está logado como gerente: " + User.Identity.Name);
        }


        [HttpGet]
        [Route("/api/v1/user/secretary")]
        [Authorize(Roles = "Secretary")]
        public IActionResult GetSecretary()
        {
            return Ok("Está logado como secretária: " + User.Identity.Name);
        }
    }
}
