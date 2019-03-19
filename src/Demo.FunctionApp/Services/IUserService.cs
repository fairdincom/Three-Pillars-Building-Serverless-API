using System;
using System.Threading.Tasks;

using Demo.FunctionApp.Models;

namespace Demo.FunctionApp.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="UserService"/> class.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the <see cref="UserCollectionResponseModel"/> instance.
        /// </summary>
        /// <returns>The <see cref="UserCollectionResponseModel"/> instance.</returns>
        Task<UserCollectionResponseModel> GetUsersAsync();

        /// <summary>
        /// Gets the <see cref="UserResponseModel"/> instance.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <returns>The <see cref="UserResponseModel"/> instance</returns>
        Task<UserResponseModel> GetUserAsync(Guid id);
    }
}