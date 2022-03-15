using Apicursos.Models;
using GestaoCursos.Context;
using GestaoCursos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoCursos.Services
{
    public class UserService : IUsersService
    {
        private readonly CoursesDbContext _usersContext;
        public UserService(CoursesDbContext usersDb)
        {
            _usersContext = usersDb;
        }


        public bool AddUsers(User users)
        {

            _usersContext.Users.Add(users);
            _usersContext.SaveChanges();
            return true;
        }

        public List<User> GetListUsers()
        {
            return _usersContext.Users.ToList();
        }

        //public User GetByEmail(string email)
        //{
        //    return Users.Where(x => x.Email.ToLower() == email.ToLower())
        //        .FirstOrDefault();
        //}
    }
}
