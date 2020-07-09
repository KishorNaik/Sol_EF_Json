using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_Api.Repository;

namespace Sol_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository = null;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //http://localhost:1546/api/users/getusersonetoonewithmodel
        [HttpPost("getusersonetoonewithmodel")]
        public async Task<IActionResult> GetUserDataOneToOneWithModelAsync()
        {
            var getUserData =
                    await
                    userRepository
                    ?.GetUserDataOneToOneWithModelAsync();

            return base.Ok((Object)getUserData);
        }

        // http://localhost:1546/api/users/getusersonetoonewithoutmodel
        [HttpPost("getusersonetoonewithoutmodel")]
        public async Task<IActionResult> GetUserDataOneToOneWithoutModelAsync()
        {
            var getUserData =
                    await
                    userRepository
                    ?.GetUserDataOneToOneWithoutModelAsync();

            var content = base.Content(getUserData, "application/json");

            return content;
        }

        //http://localhost:1546/api/users/getusersonetomanywithmodel
        [HttpPost("getusersonetomanywithmodel")]
        public async Task<IActionResult> GetUserDataOneToManyWithModelAsync()
        {
            var getUserData =
                    await
                    userRepository
                    ?.GetUserDataOneToManyWithModelAsync();

            return base.Ok((Object)getUserData);
        }

        // http://localhost:1546/api/users/getusersonetomanywithoutmodel
        [HttpPost("getusersonetomanywithoutmodel")]
        public async Task<IActionResult> GetUserDataOneToManyWithoutModelAsync()
        {
            var getUserData =
                    await
                    userRepository
                    ?.GetUserDataOneToManyWithoutModelAsync();

            var content = base.Content(getUserData, "application/json");

            return content;
        }
    }
}