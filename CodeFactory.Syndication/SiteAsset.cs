using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodeFactory.Syndication
{
    /// <summary>
    /// Describes an asset, like an image, on a website
    /// </summary>
    [DebuggerDisplay("{RelativePath}")]
    public class SiteAsset
    {
        /// <summary>
        /// Gets or sets media-type of the described asset.
        /// </summary>
        /// <value>The type of the media.</value>
        public string MediaType { get; set; }

        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the relative path from the site root.
        /// </summary>
        /// <value>The relative path.</value>
        public Uri RelativePath { get; set; }

        /// <summary>
        /// Gets or sets the value of the asset.
        /// </summary>
        /// <value>The value.</value>
        public IEnumerable<byte> Value { get; set; }
    }
}
