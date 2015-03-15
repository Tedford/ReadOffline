using System.ServiceModel.Syndication;

namespace CodeFactory.Syndication
{
    /// <summary>
    /// Products a representation of an article identified by an entry in a AtomPub/RSS feed.
    /// </summary>
    public interface IArticleClassifier
    {
        /// <summary>
        /// Classifies the specified item into an article.
        /// </summary>
        /// <param name="feed">The feed containing the article.</param>
        /// <param name="item">The article to identify.</param>
        /// <returns>A description of the <see cref="Article" />.</returns>
        Article Classify(SyndicationFeed feed, SyndicationItem item);
    }
}
