using System.Collections.Generic;

namespace Demo.FunctionApp.Models
{
    /// <summary>
    /// This represents the base response model entity for collection.
    /// </summary>
    /// <typeparam name="T">Type of response model.</typeparam>
    public abstract class BaseCollectionResponseModel<T>
    {
        /// <summary>
        /// Initialized a new instance of the <see cref="BaseCollectionResponseModel{T}"/> class.
        /// </summary>
        protected BaseCollectionResponseModel()
        {
            this.Items = new List<T>();
        }

        /// <summary>
        /// Gets the list of items.
        /// </summary>
        public virtual List<T> Items { get; }
    }
}