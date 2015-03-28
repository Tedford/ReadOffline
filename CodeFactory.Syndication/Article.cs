using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodeFactory.Syndication
{
    /// <summary>
    /// Represents a website which is typically a single web page consisting of textual and image content
    /// </summary>
    [DebuggerDisplay("{Url} - {Title}")]
    public class Article : WebSite
    {
        private readonly List<SiteAsset> _assets = new List<SiteAsset>();

        /// <summary>
        /// Gets or sets the authors of the article.
        /// </summary>
        /// <value>The authors.</value>
        public IEnumerable<string> Authors { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public IEnumerable<string> Categories { get; set; }

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
        /// Initializes a new instance of the <see cref="Article"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <exception cref="System.ArgumentNullException">uri</exception>
        public Article(Uri uri)
            : base(uri)
        {
        }

    }
}
