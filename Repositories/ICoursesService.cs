using GestaoCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoCursos.Repositories
{
   public  interface ICoursesService
    {
        bool AddCourses(Courses courses);
        List<Courses> GetListCourses();
        Courses GetCoursesByStatus(string status);
        bool DeleteCourses(int id);
        bool UpdateCourses(Courses courses);
    }
}
