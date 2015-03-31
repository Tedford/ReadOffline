using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Ebook
{
    /// <summary>
    /// Represents a digital publication
    /// </summary>
    public class Publication
    {
        /// <summary>
        /// Gets or sets the chapters which comprise the publication.
        /// </summary>
        /// <value>The chapters.</value>
        public List<Chapter> Chapters { get; set; }
        /// <summary>
        /// Gets or sets the metadata describing the publication.
        /// </summary>
        /// <value>The metadata.</value>
        public Opf.OpfDocument Metadata { get; set; }

        /// <summary>
        /// Gets or sets the table of contents for the publication.
        /// </summary>
        /// <value>The table of contents.</value>
        public TableOfContents TableOfContents { get; set; }

        public Publication()
        {
            Chapters = new List<Chapter>();
            Metadata = new Opf.OpfDocument();
            TableOfContents = new TableOfContents();
        }
    }
}
