using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;

namespace CodeFactory.Syndication.Microsoft
{
    /// <summary>
    /// An implementation of <see cref="IArticleClassifier"/> which implements the structural conventions found in Microsoft 
    /// published articles from MSDN and Technet
    /// </summary>
    public class MicrosoftArticleClassifier : IArticleClassifier
    {
        private const string ExtensionNamespace = "http://purl.org/dc/elements/1.1/";
        private const string AuthorExtension = "creator";

        /// <summary>
        /// Classifies the specified item into an article.
        /// </summary>
        /// <param name="feed">The feed containing the article.</param>
        /// <param name="item">The article to identify.</param>
        /// <returns>A description of the <see cref="Article" />.</returns>
        /// <exception cref="System.IO.InvalidDataException">The title should follow the format {category}:{Title}</exception>
        public Article Classify(SyndicationFeed feed, SyndicationItem item)
        {
            IEnumerable<string> parts = item.Title.Text.Split(':').Select(i => i.Trim());

            if (parts.Count() < 2)
            {
                throw new InvalidDataException("The title should follow the format {category}:{Title}");
            }

            Article article = new Article(new Uri(item.Id))
            {
                Authors = item.ElementExtensions.ReadElementExtensions<string>(AuthorExtension, ExtensionNamespace),
                Title = string.Join(": ", parts.Skip(1)),
                Categories = parts.Take(1),
                Published = item.PublishDate,
                Source = feed.Title.Text
            };


            return article;
        }
    }
}
