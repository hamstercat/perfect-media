using System.Collections.Generic;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// Images available related to a specific movie.
    /// </summary>
    public class AvailableMovieImages
    {
        /// <summary>
        /// Gets or sets the fanarts.
        /// </summary>
        /// <value>
        /// The fanarts.
        /// </value>
        public IEnumerable<Image> Fanarts { get; set; }

        /// <summary>
        /// Gets or sets the posters.
        /// </summary>
        /// <value>
        /// The posters.
        /// </value>
        public IEnumerable<Image> Posters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableMovieImages"/> class.
        /// </summary>
        public AvailableMovieImages()
        {
            Fanarts = new List<Image>();
            Posters = new List<Image>();
        }
    }
}
