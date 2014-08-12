using System.Collections.Generic;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// All movie certifications for a movie based by country.
    /// </summary>
    public class MovieCertificationResult
    {
        /// <summary>
        /// Gets or sets the certifications.
        /// </summary>
        /// <value>
        /// The certification.
        /// </value>
        public List<CountryCertification> Countries { get; set; }
    }
}
