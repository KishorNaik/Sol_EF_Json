using Sol_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Api.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUserDataWithModelAsync();

        Task<String> GetUserDataWithoutModelAsync();
    }
}