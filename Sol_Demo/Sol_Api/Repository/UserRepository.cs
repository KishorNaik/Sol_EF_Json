using EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Sol_Api.Models;
using Sol_Api.Repository.DbModelContext;
using Sol_Api.Repository.DbModelContext.DbResultSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Api.Repository
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly EFCoreContext eFCoreContext = null;

        public UserRepository(EFCoreContext eFCoreContext)
        {
            this.eFCoreContext = eFCoreContext;
        }

        async Task<IEnumerable<UserModel>> IUserRepository.GetUserDataWithModelAsync()
        {
            IEnumerable<UserModel> userModelData = null;
            try
            {
                string command = "EXEC uspGetUsers";

                var userJsonData =
                        (
                            await
                                eFCoreContext
                                .SqlQueryAsync<UserResultSet>(command)
                        )
                        ?.FirstOrDefault();

                userModelData = JsonConvert.DeserializeObject<List<UserModel>>(userJsonData.UserJson);

                return userModelData;
            }
            catch
            {
                throw;
            }
        }

        async Task<string> IUserRepository.GetUserDataWithoutModelAsync()
        {
            try
            {
                string command = "EXEC uspGetUsers";

                var userJsonData =
                        (
                            await
                                eFCoreContext
                                .SqlQueryAsync<UserResultSet>(command)
                        )
                        ?.FirstOrDefault();

                return userJsonData.UserJson;
            }
            catch
            {
                throw;
            }
        }
    }
}