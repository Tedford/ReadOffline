using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Ebook.Generation
{
    /// <summary>
    /// Describes an entity which is capable of building a book
    /// </summary>
    public interface IBookBinder
    {
        /// <summary>
        /// Binds the publication information into an ebook.
        /// </summary>
        /// <param name="publication">The publication to bind.</param>
        /// <returns>The electronic book.</returns>
        Book Bind(Publication publication);
    }
}
