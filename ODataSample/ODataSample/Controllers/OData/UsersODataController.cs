using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ODataSample.Services;
using ODataSample.Models;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;

namespace ODataSample.Controllers.OData
{
    
    public class UsersODataController : ODataController
    {
        private IUsersService _usersService { get; set; }

        public UsersODataController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        //[HttpGet]
        [ODataRoute(pathTemplate: "users", RouteName = "odata")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get(ODataQueryOptions<User> query)
        {
            var data = _usersService.Get().AsQueryable();
            return Ok(data);
        }
    }
}
