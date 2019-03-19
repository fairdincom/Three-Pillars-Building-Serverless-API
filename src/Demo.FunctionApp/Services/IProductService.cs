using System;
using System.Threading.Tasks;

using Demo.FunctionApp.Models;

namespace Demo.FunctionApp.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="ProductService"/> class.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets the <see cref="ProductCollectionResponseModel"/> instance.
        /// </summary>
        /// <returns>The <see cref="ProductCollectionResponseModel"/> instance.</returns>
        Task<ProductCollectionResponseModel> GetProductsAsync();

        /// <summary>
        /// Gets the <see cref="ProductResponseModel"/> instance.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>The <see cref="ProductResponseModel"/> instance</returns>
        Task<ProductResponseModel> GetProductAsync(Guid id);
    }
}