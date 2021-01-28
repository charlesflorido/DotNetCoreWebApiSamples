using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ODataSample.Models;

namespace ODataSample.Services
{
    public class UsersService : IUsersService
    {
        public IEnumerable<User> Get()
        {
            var list = new List<User>();

            list.Add(new User(1, "Leonardo Cotton"));
            list.Add(new User(2, "Blythe Leblanc"));
            list.Add(new User(3, "Ellisha Villa"));
            list.Add(new User(4, "Alex Millicent"));
            list.Add(new User(5, "Makenzi Mcintosh"));
            list.Add(new User(6, "Kendra Nelson"));
            list.Add(new User(7, "Tiegan Ayala"));
            list.Add(new User(8, "Thallia Edwards"));
            list.Add(new User(9, "Anniyah Mcfarlane"));
            list.Add(new User(10, "Kendall Bletran"));

            return list;
        }
    }
}
