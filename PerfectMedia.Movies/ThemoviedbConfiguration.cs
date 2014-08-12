
namespace PerfectMedia.Movies
{
    /// <summary>
    /// Themoviedb.org general configuration.
    /// </summary>
    public class ThemoviedbConfiguration
    {
        /// <summary>
        /// Gets or sets the image configuration.
        /// </summary>
        /// <value>
        /// The image configuration.
        /// </value>
        public ImageConfiguration Images { get; set; }
    }

    /// <summary>
    /// Themoviedb.org image general configuration
    /// </summary>
    public class ImageConfiguration
    {
        /// <summary>
        /// Gets or sets the secure base URL to prepend to all image queries.
        /// </summary>
        /// <value>
        /// The secure base URL.
        /// </value>
        public string SecureBaseUrl { get; set; }
    }
}
