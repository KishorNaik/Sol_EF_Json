using Sol_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Api.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUserDataOneToOneWithModelAsync();

        Task<String> GetUserDataOneToOneWithoutModelAsync();

        Task<IEnumerable<UserModel>> GetUserDataOneToManyWithModelAsync();

        Task<String> GetUserDataOneToManyWithoutModelAsync();
    }
}