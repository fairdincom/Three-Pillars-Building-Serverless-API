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

namespace Demo.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for products.
    /// </summary>
    public static class ProductHttpTrigger
    {
        /// <summary>
        /// Gets the <see cref="IFunctionFactory"/> instance.
        /// </summary>
        public static IFunctionFactory Factory { get; } = new FunctionFactory<AppModule>();

        /// <summary>
        /// Gets the list of products.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>The list of products.</returns>
        [FunctionName(nameof(GetProducts))]
        #region
        [OpenApiOperation("list", "product", Summary = "Gets the list of products", Description = "This gets the list of products.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter("limit", In = ParameterLocation.Query, Required = false, Type = typeof(int), Description = "The number of products to return")]
        [OpenApiResponseBody(HttpStatusCode.OK, "application/json", typeof(ProductCollectionResponseModel), Summary = "Product collection response")]
        #endregion
        public static async Task<IActionResult> GetProducts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            var result = await Factory.Create<IGetProductsFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequest, IActionResult>(req)
                                      .ConfigureAwait(false);

            return result;
        }
    }
}