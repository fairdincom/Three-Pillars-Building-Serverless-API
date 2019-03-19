using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.Extensions.Logging;

namespace Demo.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="GetProductsFunction"/> class.
    /// </summary>
    public interface IGetProductsFunction : IFunction<ILogger>
    {
    }
}