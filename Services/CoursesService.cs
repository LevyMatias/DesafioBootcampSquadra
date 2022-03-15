using GestaoCursos.Context;
using GestaoCursos.Models;
using GestaoCursos.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GestaoCursos.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly CoursesDbContext _coursesContext;

        public CoursesService(CoursesDbContext coursesDb)
        {
            _coursesContext = coursesDb;
        }

        public bool AddCourses(Courses curses)
        {
            _coursesContext.Courses.Add(curses);
            _coursesContext.SaveChanges();
            return true;
        }

        public bool DeleteCourses(int id)
        {
            var deleteCourses = _coursesContext.Courses.Where(x => x.Id == id).FirstOrDefault();
            _coursesContext.Courses.Remove(deleteCourses);
            _coursesContext.SaveChanges();
            return true;
        }

        public Courses GetCoursesByStatus(string status)
        {
            throw new System.NotImplementedException();
        }

        //public Courses GetCoursesByStatus(string status)
        //{
        //    return _coursesContext.Courses.Where(x => x.Status == status).FirstOrDefault();
        //}

        public List<Courses> GetListCourses()
        {
            return _coursesContext.Courses.ToList();
        }

        // nao consegui resolver
        public bool UpdateCourses(Courses courses)
        {
            _coursesContext.Courses.Attach(courses);
            _coursesContext.Entry(courses).State = EntityState.Modified;
            return true;
        }
    }

}

