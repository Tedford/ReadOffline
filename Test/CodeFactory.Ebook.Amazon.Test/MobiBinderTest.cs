using System;
using CodeFactory.Ebook.Amazon.Generation;
using CodeFactory.Ebook.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFactory.Ebook.Amazon.Test
{
    [TestClass]
    public class MobiBinderTest
    {
        [TestMethod]
        public void Instantiate()
        {
            IBookBinder binder = new MobiBinder();
        }

        [TestMethod]
        public void NullPublication()
        {
            IBookBinder binder = new MobiBinder();
            try
            {
                binder.Bind(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("publication", ex.ParamName);
            }
        }

        [TestMethod]
        public void EmptyContent()
        {
            Publication publication = new Publication
            {
                Metadata = new Opf.OpfDocument
                {
                    Metadata = new Opf.PublicationMetadata
                    {
                        Title = "Example book"
                    }
                }
            };

            IBookBinder binder = new MobiBinder();
            Book book = binder.Bind(publication);
            Assert.IsNotNull(book);
            Assert.AreEqual(publication.Metadata.Metadata.Title, book.Title);
        }
    }
}
