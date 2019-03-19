using Aliencube.AzureFunctions.Extensions.OpenApi;
using Aliencube.AzureFunctions.Extensions.OpenApi.Abstractions;

using Demo.FunctionApp;
using Demo.FunctionApp.Configurations;
using Demo.FunctionApp.Functions;
using Demo.FunctionApp.Services;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(StartUp))]

namespace Demo.FunctionApp
{
    /// <summary>
    /// This represents the entity to register dependencies.
    /// </summary>
    public class StartUp : IWebJobsStartup
    {
        /// <inheritdoc />
        public void Configure(IWebJobsBuilder builder)
        {
            this.Register(builder.Services);
        }

        private void Register(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();

            services.AddTransient<IDocumentHelper, DocumentHelper>();
            services.AddTransient<IDocument, Document>();
            services.AddTransient<ISwaggerUI, SwaggerUI>();
            services.AddTransient<IRenderOpeApiDocumentFunction, RenderOpeApiDocumentFunction>();
            services.AddTransient<IRenderSwaggerUIFunction, RenderSwaggerUIFunction>();

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IGetUsersFunction, GetUsersFunction>();
        }
    }
}