using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Syndication
{

    /// <summary>
    /// An in-memory representation of a website
    /// </summary>
    [DebuggerDisplay("{Url}")]
    public class WebSite : CodeFactory.Syndication.IWebSite
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
        public Maybe<string> Html { get; private set; }

        /// <summary>
        /// Gets the URL to where the site was downloaded.
        /// </summary>
        /// <value>The URL.</value>
        public Uri Url { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="WebSite" /> class.
        /// </summary>
        /// <param name="uri">The URI to the represented website.</param>
        /// <exception cref="System.ArgumentNullException">uri</exception>
        public WebSite(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (!uri.IsAbsoluteUri)
            {
                throw new ArgumentException("An absolute URL must be specified", "uri");
            }

            if (!string.Equals(uri.Scheme, "http", StringComparison.CurrentCultureIgnoreCase) &&
                !string.Equals(uri.Scheme, "https", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new ArgumentException("The provided URI must reference an HTTP or HTTPS resource.", "uri");
            }

            Html = new Maybe<string>();
            Url = uri;
        }

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


        /// <summary>
        /// Download the source of the website.
        /// </summary>
        public async void Download()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(Url);
                if (!response.IsSuccessStatusCode)
                {
                    string message = string.Format("Failed to download the site from {0}", Url);
                    throw new InvalidOperationException(message);
                }

                string body = await response.Content.ReadAsStringAsync();
                string html = ProcessHtml(body);
                Html = new Maybe<string>(html);
            }
        }

        /// <summary>
        /// Processes the website HTML.
        /// </summary>
        /// <param name="body">The source of the website.</param>
        /// <returns>The post-processed HTML.</returns>
        protected virtual string ProcessHtml(string body)
        {
            return body;
        }
    }
}
