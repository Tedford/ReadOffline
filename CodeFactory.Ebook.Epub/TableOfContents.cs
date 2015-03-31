using System.Collections.Generic;

namespace CodeFactory.Ebook
{
    /// <summary>
    /// Provide a structured and navigable detail of the items contained within the publication
    /// </summary>
    public class TableOfContents
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the entries of the publication.
        /// </summary>
        /// <value>The contents.</value>
        public List<ChapterLink> Chapters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableOfContents"/> class.
        /// </summary>
        public TableOfContents()
        {
            Chapters = new List<ChapterLink>();
        }
    }
}
