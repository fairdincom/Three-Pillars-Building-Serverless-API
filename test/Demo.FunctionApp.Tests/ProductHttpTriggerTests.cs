using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Demo.FunctionApp.Functions;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Demo.FunctionApp.Tests
{
    [TestClass]
    public class ProductHttpTriggerTests
    {
        [TestMethod]
        public async Task Given_Factory_Method_Should_Return_Result()
        {
            // Arrange
            var resultInvoked = "lorem ipsum";
            var payload = "Hello World";
            var result = new OkObjectResult(payload);

            var function = new Mock<IGetProductsFunction>();
            function.Setup(p => p.InvokeAsync<HttpRequest, IActionResult>(
                                It.IsAny<HttpRequest>(),
                                It.IsAny<FunctionOptionsBase>()))
                    .ReturnsAsync(result);

            var factory = new Mock<IFunctionFactory>();
            factory.Setup(p => p.Create<IGetProductsFunction, ILogger>(It.IsAny<ILogger>()))
                   .Returns(function.Object);

            factory.SetupProperty(p => p.ResultInvoked);

            var req = new Mock<HttpRequest>();
            var log = new Mock<ILogger>();

            // Act
            ProductHttpTrigger.Factory = factory.Object;

            var response = await ProductHttpTrigger.GetProducts(req.Object, log.Object)
                                                   .ConfigureAwait(false);

            // Assert
            response.Should().BeAssignableTo<OkObjectResult>()
                    .Which.Value
                          .Should().Be(payload);

            factory.Object.ResultInvoked.Should().Be(resultInvoked);
        }
    }
}
