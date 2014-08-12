using System.Collections.Generic;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// Search results of a movie credits.
    /// </summary>
    public class MovieActorsResult
    {
        /// <summary>
        /// Gets or sets the casts.
        /// </summary>
        /// <value>
        /// The casts.
        /// </value>
        public List<Cast> Cast { get; set; }

        /// <summary>
        /// Gets or sets the crew.
        /// </summary>
        /// <value>
        /// The crew.
        /// </value>
        public List<Crew> Crew { get; set; }
    }
}
