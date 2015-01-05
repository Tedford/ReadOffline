using System.Linq;
using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Linq;
using System.ServiceModel.Syndication;

namespace CodeFactory.Syndication.Test
{
    [TestClass]
    public class DateNormalizingXmlTextReaderTest
    {
        [TestMethod]
        public void BadLastBuildDate()
        {
            Run("RSS 2.0 BadLastBuildDate.xml");
        }

        [TestMethod]
        public void BadPublishDate()
        {
            Run("RSS 2.0 BadPublishDate.xml");
        }

        [TestMethod]
        public void WellFormed()
        {
            Run("RSS 2.0 Well-Formed.xml");
        }

        private static void Run(string input)
        {
            Rss20FeedFormatter formatter = new Rss20FeedFormatter();

            using (Stream s = GetResource(input))
            using (DateNormalizingXmlTextReader reader = new DateNormalizingXmlTextReader(s))
            {
                formatter.ReadFrom(reader);
            }

            VerifyFeed(formatter.Feed);
        }


        private static Stream GetResource(string name)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resource = asm.GetManifestResourceNames().First(i => i.Contains(name));
            var stream = asm.GetManifestResourceStream(resource);
            return stream;
        }

        private static void VerifyFeed(SyndicationFeed feed)
        {
            Assert.AreEqual(1, feed.Items.Count());
            Assert.AreEqual("MSDN Magazine RSS Feed:", feed.Title.Text);
            Assert.AreEqual("Thank You for subscribing to our RSS Feed.", feed.Description.Text);
            Assert.AreEqual("en-us", feed.Language);
            Assert.AreEqual("© 2015 Microsoft Corporation. All rights reserved.", feed.Copyright.Text);
            Assert.AreEqual(new DateTimeOffset(2015, 1, 2, 0, 0, 0, new TimeSpan(0)), feed.LastUpdatedTime);
            Assert.AreEqual("\"http://www.microsoft.com/technet/technetmag/images/tnlogo.gif\"", feed.ImageUrl.ToString());

            var item = feed.Items.ElementAt(0);
            Assert.AreEqual("http://msdn.microsoft.com/magazine/a687d635-a012-4c59-9ed5-54b9bfa98317", item.Id);
            Assert.AreEqual("Visual Basic .NET: 14 Top Improvements in Visual Basic 14", item.Title.Text);
            Assert.AreEqual("January 2015<br/><br/>Microsoft has rebuilt Visual Basic 14 from the ground up. VB team member Lucian Wischik presents the Microsoft VB Language Design Team’s top 14 improvements in the new Visual Basic 14.", item.Summary.Text);
            Assert.AreEqual(new DateTimeOffset(2015, 1, 4, 11, 43, 26, new TimeSpan(0)), item.PublishDate);
        }
    }
}
