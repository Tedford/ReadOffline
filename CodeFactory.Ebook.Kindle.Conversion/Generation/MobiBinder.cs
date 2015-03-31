using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFactory.Ebook;
using CodeFactory.Ebook.Generation;
using CodeFactory.Ebook.Opf;

namespace CodeFactory.Ebook.Amazon.Generation
{
    /// <summary>
    /// An implementation of <see cref="IBookBinder"/> which produces .mobi files compatible with the Amazon Kindle
    /// </summary>
    public class MobiBinder : IBookBinder
    {
        /// <summary>
        /// Binds the publication information into an ebook.
        /// </summary>
        /// <param name="publication">The publication to bind.</param>
        /// <returns>The electronic book.</returns>
        /// <exception cref="System.ArgumentNullException">publication</exception>
        public Book Bind(Publication publication)
        {
            if (publication == null)
            {
                throw new ArgumentNullException("publication");
            }

            if (publication.Metadata == null)
            {
                throw new InvalidOperationException();
            }

            if (publication.Metadata.Metadata == null)
            {
                throw new InvalidOperationException();
            }

            if (publication.TableOfContents == null)
            {
                throw new InvalidOperationException();
            }

            if (publication.Chapters == null)
            {
                throw new InvalidOperationException();
            }

            Book book = new Book
            {
                Title = publication.Metadata.Metadata.Title,
                Format = Constants.Format,
                Extension = Constants.Extension
            };

            return book;
        }
    }
}
