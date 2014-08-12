
namespace PerfectMedia.Movies
{
    /// <summary>
    /// Represents a movie set (related movies, sequels, etc.)
    /// </summary>
    public class MovieSet
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the poster path.
        /// </summary>
        /// <value>
        /// The poster path.
        /// </value>
        public string PosterPath { get; set; }

        /// <summary>
        /// Gets or sets the fanart path.
        /// </summary>
        /// <value>
        /// The fanart path.
        /// </value>
        public string BackdropPath { get; set; }
    }
}
