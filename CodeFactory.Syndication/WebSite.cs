using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Syndication
{

    /// <summary>
    /// An in-memory representation of a website
    /// </summary>
    public class WebSite
    {
        private List<SiteAsset> _assets = new List<SiteAsset>();

        /// <summary>
        /// Gets the assets which comprise the site.
        /// </summary>
        /// <value>The assets.</value>
        public IEnumerable<SiteAsset> Assets
        {
            get { return _assets; }
        }

        /// <summary>
        /// Gets or sets the HTML of the web site.
        /// </summary>
        /// <value>The HTML.</value>
        public string Html { get; set; }

        /// <summary>
        /// Gets the URL to where the site was downloaded.
        /// </summary>
        /// <value>The URL.</value>
        public Uri Url { get; set; }

        /// <summary>
        /// Adds the specified asset to the site.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <exception cref="System.ArgumentNullException">asset</exception>
        public void Add(SiteAsset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException("asset");
            }

            _assets.Add(asset);
        }
    }
}
