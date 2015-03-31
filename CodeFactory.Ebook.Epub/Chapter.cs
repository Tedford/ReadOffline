using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Ebook
{
    /// <summary>
    /// Represents a single logical division within a publication
    /// </summary>
    public class Chapter
    {
        /// <summary>
        /// Gets or sets the assets (images, tables) referenced by the chapter prose.
        /// </summary>
        /// <value>The assets.</value>
        public List<Asset> Assets { get; set; }

        /// <summary>
        /// Gets or sets the body of the chapter.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chapter"/> class.
        /// </summary>
        public Chapter()
        {
            Assets = new List<Asset>();
        }
    }
}
