#region
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection;
using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;
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
#endregion

namespace Demo.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for users.
    /// </summary>
    public static class UserHttpTrigger
    {
        /// <summary>
        /// Gets the <see cref="IFunctionFactory"/> instance.
        /// </summary>
        public static IFunctionFactory Factory { get; set; } = new FunctionFactory<AppModule>();

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
        public static async Task<IActionResult> GetUsers(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users")] HttpRequest req,
            ILogger log)
        {
            var result = await Factory.Create<IGetUsersFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequest, IActionResult>(req)
                                      .ConfigureAwait(false);

            return result;
        }
    }
}