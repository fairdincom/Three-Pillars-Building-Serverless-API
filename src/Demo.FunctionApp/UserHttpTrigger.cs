using System;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Extensions;
using Aliencube.AzureFunctions.Extensions.DependencyInjection.Triggers.Abstractions;
using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using Aliencube.AzureFunctions.Extensions.OpenApi.Enums;

using Demo.FunctionApp.Functions;
using Demo.FunctionApp.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Demo.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for users.
    /// </summary>
    public class UserHttpTrigger : TriggerBase<ILogger>
    {
        private readonly IGetUsersFunction _function;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHttpTrigger"/> class.
        /// </summary>
        /// <param name="function"><see cref="IGetUsersFunction"/> instance.</param>
        public UserHttpTrigger(IGetUsersFunction function)
        {
            this._function = function ?? throw new ArgumentNullException(nameof(function));
        }

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>The list of users.</returns>
        [FunctionName(nameof(GetUsers))]
        #region
        [OpenApiOperation("list", "user", Summary = "Gets the list of users", Description = "This gets the list of users.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter("limit", In = ParameterLocation.Query, Required = false, Type = typeof(int), Description = "The number of users to return")]
        [OpenApiResponseBody(HttpStatusCode.OK, "application/json", typeof(UserCollectionResponseModel), Summary = "User collection response")]
        #endregion
        public async Task<IActionResult> GetUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequest req,
            ILogger log)
        {
            var result = await this._function
                                   .AddLogger<IGetUsersFunction, ILogger>(log)
                                   .InvokeAsync<HttpRequest, IActionResult>(req)
                                   .ConfigureAwait(false);

            return result;
        }
    }
}