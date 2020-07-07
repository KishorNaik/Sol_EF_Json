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

        [HttpPost("getuserswithmodel")]
        public async Task<IActionResult> GetUserDataWithModelAsync()
        {
            var getUserData =
                    await
                    userRepository
                    ?.GetUserDataWithModelAsync();

            return base.Ok((Object)getUserData);
        }

        [HttpPost("getuserswithoutmodel")]
        public async Task<IActionResult> GetUserDataWithoutModelAsync()
        {
            var getUserData =
                    await
                    userRepository
                    ?.GetUserDataWithoutModelAsync();

            var content = base.Content(getUserData, "application/json");

            return content;
        }
    }
}