namespace Demo.FunctionApp.Models
{
    /// <summary>
    /// This represents the base response model entity.
    /// </summary>
    public abstract class BaseResponseModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public virtual string Id { get; set; }
    }
}