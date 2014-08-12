using System.Collections.Generic;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// Collection of movie sets metadata that was found in a search.
    /// </summary>
    public class SearchCollectionResult
    {
        /// <summary>
        /// Gets or sets the movie sets.
        /// </summary>
        /// <value>
        /// The movie sets.
        /// </value>
        public List<MovieSet> Results { get; set; }
    }
}
