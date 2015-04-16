using System;

namespace CodeFactory.Syndication
{
    public interface IWebSite
    {
        /// <summary>
        /// Gets the assets which comprise the site.
        /// </summary>
        /// <value>The assets.</value>
        System.Collections.Generic.IEnumerable<SiteAsset> Assets { get; }

        /// <summary>
        /// Gets or sets the HTML of the web site.
        /// </summary>
        /// <value>The HTML.</value>
        CodeFactory.Maybe<string> Html { get; }

        /// <summary>
        /// Gets the URL to where the site was downloaded.
        /// </summary>
        /// <value>The URL.</value>
        Uri Url { get; }

        /// <summary>
        /// Adds the specified asset to the site.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <exception cref="System.ArgumentNullException">asset</exception>
        void Add(SiteAsset asset);

        /// <summary>
        /// Download the source of the website.
        /// </summary>
        void Download();
    }
}
