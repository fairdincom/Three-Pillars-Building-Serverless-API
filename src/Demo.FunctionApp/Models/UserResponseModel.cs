namespace Demo.FunctionApp.Models
{
    /// <summary>
    /// This represents the response model entity for user.
    /// </summary>
    public class UserResponseModel : BaseResponseModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public virtual string Username { get; set; }
    }
}