using System.Linq;
using System;
using System.Reflection;
using System.ServiceModel.Syndication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;

namespace CodeFactory.Syndication.Test
{
    [TestClass]
    public class ArticleCrawlerTest
    {
        [TestMethod]
        public void Instantiate()
        {
            ArticleCrawler crawler = new ArticleCrawler();
        }

        [TestMethod]
        public void Crawl()
        {
            Article article = CreateArticle();
            ArticleCrawler crawler = new ArticleCrawler();
            crawler.Crawl(article);
        }

        private static Article CreateArticle()
        {
            //SyndicationFeed feed;
            Article article = new Article(new Uri("http://msdn.microsoft.com/en-us/magazine/dn890368.aspx"));

            var asm = Assembly.GetExecutingAssembly();
            var resource = asm.GetManifestResourceNames().First(i => i.Contains("MsdnArticle.xml"));
            using (var stream = asm.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                article.Html = reader.ReadToEnd();
            }

            //return feed;


            return article;
        }
    }
}
