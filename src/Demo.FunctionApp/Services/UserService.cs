using System;
using System.Threading.Tasks;

using Demo.FunctionApp.Models;

namespace Demo.FunctionApp.Services
{
    /// <summary>
    /// This represents the service entity for product.
    /// </summary>
    public class UserService : IUserService
    {
        /// <inheritdoc />
        public async Task<UserCollectionResponseModel> GetUsersAsync()
        {
            var user = new UserResponseModel() { Id = Guid.NewGuid().ToString(), Username = "Awesome User" };
            var users = new UserCollectionResponseModel() { Items = { user } };

            return await Task.FromResult(users).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<UserResponseModel> GetUserAsync(Guid id)
        {
            var user = new UserResponseModel() { Id = id.ToString(), Username = "Awesome User" };

            return await Task.FromResult(user).ConfigureAwait(false);
        }
    }
}