using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ODataSample.Models;

namespace ODataSample.Services
{
    public interface IUsersService
    {
        IEnumerable<User> Get();
    }
}
