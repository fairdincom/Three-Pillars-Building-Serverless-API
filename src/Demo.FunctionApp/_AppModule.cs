using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;
using Aliencube.AzureFunctions.Extensions.OpenApi;
using Aliencube.AzureFunctions.Extensions.OpenApi.Abstractions;

using Demo.FunctionApp.Configurations;
using Demo.FunctionApp.Functions;
using Demo.FunctionApp.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Demo.FunctionApp
{
    /// <summary>
    /// This represents the entity to register dependencies.
    /// </summary>
    public class AppModule : Module
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();

            services.AddTransient<IDocumentHelper, DocumentHelper>();
            services.AddTransient<IDocument, Document>();
            services.AddTransient<ISwaggerUI, SwaggerUI>();
            services.AddTransient<IRenderOpeApiDocumentFunction, RenderOpeApiDocumentFunction>();
            services.AddTransient<IRenderSwaggerUIFunction, RenderSwaggerUIFunction>();

            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IGetProductsFunction, GetProductsFunction>();
        }
    }
}