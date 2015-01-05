using System.Linq;
using System;
using System.Reflection;
using System.ServiceModel.Syndication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace CodeFactory.Syndication.Test
{
    [TestClass]
    public class Rss20CrawlerTest
    {
        [TestMethod]
        public void Instantiate()
        {
            Rss20Crawler crawler = new Rss20Crawler();
        }

        [TestMethod]
        public void Crawl()
        {
            SyndicationFeed feed = CreateFeed();
            Rss20Crawler crawler = new Rss20Crawler();
            crawler.Crawl(feed, feed.Items.First());
        }

        private static SyndicationFeed CreateFeed()
        {
            SyndicationFeed feed;

            var asm = Assembly.GetExecutingAssembly();
            var resource = asm.GetManifestResourceNames().First(i => i.Contains("RSS 2.0 Well-Formed.xml"));
            using (var stream = asm.GetManifestResourceStream(resource))
            using (XmlReader reader = XmlReader.Create(stream))
            {
                feed = SyndicationFeed.Load(reader);
            }

            return feed;
        }
    }
}
