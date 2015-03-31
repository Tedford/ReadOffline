
namespace CodeFactory.Ebook
{
    /// <summary>
    /// Describes a line item within the table of contents
    /// </summary>
    public class ChapterLink
    {
        /// <summary>
        /// Gets or sets the category, if any, to which the item belongs.
        /// </summary>
        /// <value>The category.</value>
        /// <remarks>This is mean for use in anthologies or technical references</remarks>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the path to the file.
        /// </summary>
        /// <value>The reference.</value>
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets the title of the chapter.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
    }
}
