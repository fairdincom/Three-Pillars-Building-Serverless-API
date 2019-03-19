using System;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Demo.FunctionApp.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace Demo.FunctionApp.Functions
{
    /// <summary>
    /// This represents the function entity to get list of products.
    /// </summary>
    public class GetUsersFunction : FunctionBase<ILogger>, IGetUsersFunction
    {
        private readonly IUserService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersFunction"/> class.
        /// </summary>
        /// <param name="service"><see cref="IUserService"/> instance.</param>
        public GetUsersFunction(IUserService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var result = await this._service.GetUsersAsync().ConfigureAwait(false);
            var content = new ContentResult()
                              {
                                  Content = JsonConvert.SerializeObject(result),
                                  ContentType = "application/json",
                                  StatusCode = (int)HttpStatusCode.OK
                              };

            return (TOutput)(IActionResult)content;
        }
    }
}