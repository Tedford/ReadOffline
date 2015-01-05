using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Syndication
{
    public class Rss20Crawler
    {
        public void Crawl(SyndicationFeed feed, SyndicationItem item)
        {
            string url = item.Id;
            WebClient client = new WebClient();
            string article = client.DownloadString(url);
        }
    }
}
