using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFactory.Ebook.Test
{
    [TestClass]
    public class PublicationTest
    {
        [TestMethod, Description("Validate that an instance of class can be created")]
        public void Instantiate()
        {
            Publication publication = new Publication();
            Assert.IsNotNull(publication.Chapters);
            Assert.AreEqual(0, publication.Chapters.Count);
            Assert.IsNotNull(publication.TableOfContents);
            Assert.AreEqual(0, publication.TableOfContents.Chapters.Count);
            Assert.IsNotNull(publication.Metadata);
        }
    }
}
