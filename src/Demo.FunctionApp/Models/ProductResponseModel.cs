namespace Demo.FunctionApp.Models
{
    /// <summary>
    /// This represents the response model entity for product.
    /// </summary>
    public class ProductResponseModel : BaseResponseModel
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public virtual decimal Price { get; set; }
    }
}