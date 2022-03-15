using GestaoCursos.Models;
using GestaoCursos.Repositories;
using GestaoCursos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestaoCursos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly ICoursesService _courses;

        public CoursesController(ILogger<CoursesController> logger, ICoursesService courses)
        {
            _logger = logger;
            _courses = courses;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCourses()
        {
            return Ok(_courses.GetListCourses());
        }

        [HttpPost]
        public IActionResult AddCourses([FromBody] Courses courses)
        {
            return Ok(_courses.AddCourses(courses));
        }

        [HttpPut]
        [Authorize(Roles = "Secretary, Manager")]
        public IActionResult UpdateCourses([FromBody] Courses courses)
        {
            return Ok(_courses.UpdateCourses(courses));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult DeleteCourses(int id)
        {
            try
            {
                return Ok(_courses.DeleteCourses(id));
            }
            catch (System.Exception)
            {

                return BadRequest(new { Message = "Você não tem permissão para deletar um curso!" });
            }
           
        }

        [HttpGet("{status}")]
        [Authorize(Roles = "Secretary,Manager")]
        public IActionResult GetCourseByStatus(string status)
        {
            try
            {
                return Ok(_courses.GetCoursesByStatus(status));
            }
            catch (System.Exception)
            {

                return BadRequest(new { Message = "Você não tem permissão para deletar um curso!" });
            }

        }
    }
}
