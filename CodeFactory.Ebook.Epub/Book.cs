using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Ebook
{
    /// <summary>
    /// A representation of the constructed ebook
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets normal file extension for the encoding format of the book.
        /// </summary>
        /// <value>The extension.</value>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the format of the ebook.
        /// </summary>
        /// <value>The format.</value>
        public string Format { get; set; }
        /// <summary>
        /// Gets or sets the title of the ebook.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the binary representation of the ebook.
        /// </summary>
        /// <value>The raw.</value>
        public IEnumerable<byte> Raw { get; set; }
    }
}
