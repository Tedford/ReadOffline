using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Ebook
{
    /// <summary>
    /// Represents a component within the the chapter
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Gets or sets the media type of the asset.
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets binary representation of the asset.
        /// </summary>
        /// <value>The bytes.</value>
        public IEnumerable<byte> Bytes { get; set; }
    }
}
