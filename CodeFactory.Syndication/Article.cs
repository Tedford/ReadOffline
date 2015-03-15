using System;
using System.Collections.Generic;

namespace CodeFactory.Syndication
{
    /// <summary>
    /// Represents a single web page which consists of textual and image content
    /// </summary>
    public class Article
    {
        private List<SiteAsset> _assets = new List<SiteAsset>();

        /// <summary>
        /// Gets or sets the authors of the article.
        /// </summary>
        /// <value>The authors.</value>
        public IEnumerable<string> Authors { get; set; }

        /// <summary>
        /// Gets the assets used within the article.
        /// </summary>
        /// <value>The assets.</value>
        public IEnumerable<SiteAsset> Assets
        {
            get { return _assets; }
        }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public IEnumerable<string> Categories { get; set; }

        /// <summary>
        /// Gets the markup representing the article
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// Gets or sets the date the article was published.
        /// </summary>
        /// <value>The published.</value>
        public DateTimeOffset Published { get; set; }

        /// <summary>
        /// Gets or sets the distribution source of the article i.e. Wired or MSDN Magazine.
        /// </summary>
        /// <value>The source.</value>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the name of the article.
        /// </summary>
        /// <value>The name.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL where the article is hosted.
        /// </summary>
        /// <value>The URL.</value>
        public Uri Url { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Article"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <exception cref="System.ArgumentNullException">uri</exception>
        public Article(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            Url = uri;
        }

        /// <summary>
        /// Adds the specified asset to the article representation.
        /// </summary>
        /// <param name="asset">The asset.</param>
        public void Add(SiteAsset asset)
        {
            _assets.Add(asset);
        }
    }
}
