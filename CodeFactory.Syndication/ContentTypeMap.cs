using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Syndication
{
    /// <summary>
    /// Maps content types to the typical file extension for that type
    /// </summary>
    public class ContentTypeMap
    {
        private static readonly Dictionary<string, string> Conventions = new Dictionary<string, string>
        { 
            { "image/gif", ".gif" },
            { "image/jpg", ".jpg" },
            { "image/jpeg", ".jpg" },
            { "image/png", ".png" }
                                                                         
        };

        /// <summary>
        /// Lookups the typically file extension for the specified content-type.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentNullException">contentType</exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public string Lookup(string contentType)
        {
            if (string.IsNullOrWhiteSpace(contentType))
            {
                throw new ArgumentNullException("contentType");
            }

            string extension;

            if (!Conventions.TryGetValue(contentType, out extension))
            {
                string message = string.Format("The requested content-type {0} is not mapped", contentType);
                throw new InvalidOperationException(message);
            }

            return extension;
        }
    }
}
