using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    /// <summary>
    /// Identifies fundamental structural components of the publication and enables reading systems to provide convenient access to them.
    /// </summary>
    [XmlRoot("guide")]
    public class Guide
    {
        /// <summary>
        /// Gets or sets the references.
        /// </summary>
        /// <value>The references.</value>
        [XmlElement("reference")]
        public List<Reference> References { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guide"/> class.
        /// </summary>
        public Guide()
        {
            References = new List<Reference>();
        }
    }
}
