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

namespace ODataSample.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersControllers : ODataController
    {
        private IUsersService _usersService { get; set; }

        public UsersControllers(IUsersService usersService)
        {
            _usersService = usersService;
        }


        //[HttpGet]
        [ODataRoute(pathTemplate: "users", RouteName = "users")]
        [EnableQuery(AllowedQueryOptions =AllowedQueryOptions.All)]
        public IActionResult Get(ODataQueryOptions<User> query)
        {
            //return Ok()
            var data = _usersService.Get().AsQueryable();
            return Ok(data);
            /*
            return Ok(new ODataResult<User>
            {
                Items = query.ApplyTo(data).Cast<User>(),
                Count = query.Count?.GetEntityCount(query.Filter?.ApplyTo(data, new ODataQuerySettings()) ?? data)
            });*/
        }
    }
}
