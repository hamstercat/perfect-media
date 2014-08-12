
namespace PerfectMedia.Movies
{
    /// <summary>
    /// Movie summary of different length.
    /// </summary>
    public class MovieSynopsis
    {
        /// <summary>
        /// Gets or sets the tagline (the shortest).
        /// </summary>
        /// <value>
        /// The tagline.
        /// </value>
        public string Tagline { get; set; }

        /// <summary>
        /// Gets or sets the outline.
        /// </summary>
        /// <value>
        /// The outline.
        /// </value>
        public string Outline { get; set; }

        /// <summary>
        /// Gets or sets the plot (the longest).
        /// </summary>
        /// <value>
        /// The plot.
        /// </value>
        public string Plot { get; set; }
    }
}
