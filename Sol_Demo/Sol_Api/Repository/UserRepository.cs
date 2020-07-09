using EntityFrameworkCore.Query;
using Microsoft.Data.SqlClient;
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

        async Task<IEnumerable<UserModel>> IUserRepository.GetUserDataOneToOneWithModelAsync()
        {
            IEnumerable<UserModel> userModelData = null;
            try
            {
                List<SqlParameter> sqlParameterList = new List<SqlParameter>();
                sqlParameterList.Add(new SqlParameter("@Command", "One-To-One"));

                string command = "EXEC uspGetUsers @Command";

                var userJsonData =
                        (
                            await
                                eFCoreContext
                                .SqlQueryAsync<UserResultSet>(command, sqlParameterList)
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

        async Task<string> IUserRepository.GetUserDataOneToOneWithoutModelAsync()
        {
            try
            {
                List<SqlParameter> sqlParameterList = new List<SqlParameter>();
                sqlParameterList.Add(new SqlParameter("@Command", "One-To-One"));

                string command = "EXEC uspGetUsers @Command";

                var userJsonData =
                        (
                            await
                                eFCoreContext
                                .SqlQueryAsync<UserResultSet>(command, sqlParameterList)
                        )
                        ?.FirstOrDefault();

                return userJsonData.UserJson;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task<IEnumerable<UserModel>> IUserRepository.GetUserDataOneToManyWithModelAsync()
        {
            IEnumerable<UserModel> userModelData = null;
            try
            {
                List<SqlParameter> sqlParameterList = new List<SqlParameter>();
                sqlParameterList.Add(new SqlParameter("@Command", "One-To-Many"));

                string command = "EXEC uspGetUsers @Command";

                var userJsonData =
                        (
                            await
                                eFCoreContext
                                .SqlQueryAsync<UserResultSet>(command, sqlParameterList)
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

        async Task<string> IUserRepository.GetUserDataOneToManyWithoutModelAsync()
        {
            try
            {
                List<SqlParameter> sqlParameterList = new List<SqlParameter>();
                sqlParameterList.Add(new SqlParameter("@Command", "One-To-Many"));

                string command = "EXEC uspGetUsers @Command";

                var userJsonData =
                        (
                            await
                                eFCoreContext
                                .SqlQueryAsync<UserResultSet>(command, sqlParameterList)
                        )
                        ?.FirstOrDefault();

                return userJsonData.UserJson;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}