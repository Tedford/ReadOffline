using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;

namespace CodeFactory.Syndication
{
    /// <summary>
    /// An implementation of <see cref="XmlTextReader"/> which intercepts and reformats date values to in normative form.  This is
    /// intended to be used with the <see cref="SyndicationFeedFormatter"/> class hierarchy.
    /// </summary>
    /// <remarks>See http://support.microsoft.com/kb/2020488 for the limitation of <see cref="SyndicationFeed.Load"/></remarks>
    public class DateNormalizingXmlTextReader : XmlTextReader
    {
        /// <summary>
        /// The default namespace of an RSS Feed
        /// </summary>
        private const string RssNamespace = "";

        /// <summary>
        /// The elements of an RSS feed which contain datetime values
        /// </summary>
        private static string[] DateElements = new[] { "pubDate", "lastBuildDate" };

        /// <summary>
        /// The normative datetime format for an RSS 2.0 feed
        /// </summary>
        /// <example>Wed Oct 07 08:00:07 GMT 2009</example>
        private const string NormativeDateFormat = "ddd MMM dd HH:mm:ss Z yyyy";
        private bool _intercept;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Xml.XmlTextReader" /> class with the specified stream.
        /// </summary>
        /// <param name="input">The stream containing the XML data to read.</param>
        public DateNormalizingXmlTextReader(Stream input)
            : base(input)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateNormalizingXmlTextReader"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public DateNormalizingXmlTextReader(string uri)
            : base(uri)
        {
        }

        /// <summary>
        /// Determines whether the element being inspected is a date
        /// </summary>
        /// <returns><c>true</c> if the element a date; otherwise, <c>false</c>.</returns>
        private bool IsReadingDate()
        {
            StringComparison algorithm = StringComparison.InvariantCultureIgnoreCase;
            bool isDateElement = string.Equals(NamespaceURI, RssNamespace, algorithm) && DateElements.Any(i => string.Equals(i, LocalName, algorithm));
            return isDateElement;
        }


        /// <summary>
        /// Checks that the current content node is an end tag and advances the reader to the next node.
        /// </summary>
        public override void ReadEndElement()
        {
            _intercept = false;
            base.ReadEndElement();
        }

        /// <summary>
        /// Checks that the current node is an element and advances the reader to the next node.
        /// </summary>
        public override void ReadStartElement()
        {
            _intercept = IsReadingDate();
            base.ReadStartElement();
        }

        /// <summary>
        /// Reads the contents of an element or a text node as a string.
        /// </summary>
        /// <returns>The contents of the element or text node. This can be an empty string if the reader is positioned on something other than an element or text node, or if there is no more text content to return in the current context.Note: The text node can be either an element or an attribute text node.</returns>
        public override string ReadString()
        {
            string value = base.ReadString();

            if (_intercept)
            {
                DateTime dt;

                if (!DateTime.TryParse(value, out dt))
                {
                    dt = DateTime.ParseExact(value, NormativeDateFormat, CultureInfo.InvariantCulture);
                }

                value = dt.ToUniversalTime().ToString("R", CultureInfo.InvariantCulture);
            }

            return value;
        }
    }
}
