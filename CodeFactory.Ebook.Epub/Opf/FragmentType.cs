using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    /// <summary>
    /// The domain of publication components
    /// </summary>
    /// <remarks>Derived from the 13th edition of the Chicago Manual of Style</remarks>
    public enum FragmentType
    {
        [XmlEnum("other")]
        Other = 0,
        [XmlEnum("cover")]
        Covert,
        [XmlEnum("title-page")]
        TitlePage,
        [XmlEnum("toc")]
        TableOfContents,
        [XmlEnum("index")]
        Index,
        [XmlEnum("glossary")]
        Gloassary,
        [XmlEnum("acknowledgements")]
        Acknowledgements,
        [XmlEnum("bibliography")]
        Bibliography,
        [XmlEnum("colophon")]
        Colophon,
        [XmlEnum("copyright-page")]
        CopyrightPage,
        [XmlEnum("dedication")]
        Dedication,
        [XmlEnum("foreword")]
        Foreword,
        [XmlEnum("loi")]
        Illustrations,
        [XmlEnum("lot")]
        Tables,
        [XmlEnum("notes")]
        Notes,
        [XmlEnum("preface")]
        Preface,
        [XmlEnum("text")]
        Text
    }

    /// <summary>
    /// Functional extensions to <see cref="FragmentType"/>.
    /// </summary>
    public static class FragementTypeExtension
    {
        /// <summary>
        /// Gets the formatted name for the fragment type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        public static string GetName(this FragmentType type)
        {
            string label = type.ToString();


            Type t = type.GetType();
            MemberInfo member = t.GetMember(label).FirstOrDefault();

            if (member != null)
            {
                var attribute = (XmlEnumAttribute)Attribute.GetCustomAttribute(member, t);

                if (attribute != null && !string.IsNullOrWhiteSpace(attribute.Name))
                {
                    label = attribute.Name;
                }
            }

            return label;
        }
    }
}
