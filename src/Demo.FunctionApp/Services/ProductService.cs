using System;
using System.Threading.Tasks;

using Demo.FunctionApp.Models;

namespace Demo.FunctionApp.Services
{
    /// <summary>
    /// This represents the service entity for product.
    /// </summary>
    public class ProductService : IProductService
    {
        /// <inheritdoc />
        public async Task<ProductCollectionResponseModel> GetProductsAsync()
        {
            var product = new ProductResponseModel() { Id = Guid.NewGuid().ToString(), Name = "Awesome Product", Price = 12.34M };
            var products = new ProductCollectionResponseModel() { Items = { product } };

            return await Task.FromResult(products).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<ProductResponseModel> GetProductAsync(Guid id)
        {
            var product = new ProductResponseModel() { Id = id.ToString(), Name = "Awesome Product", Price = 12.34M };

            return await Task.FromResult(product).ConfigureAwait(false);
        }
    }
}