using Apicursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoCursos.Repositories
{
    public interface IUsersService
    {
        bool AddUsers(User users);
        List<User> GetListUsers();
    }
}
