
namespace PerfectMedia.Movies
{
    /// <summary>
    /// Movie certification based by country.
    /// </summary>
    public class CountryCertification
    {
        /// <summary>
        /// Gets or sets the ISO 3166-1 country code.
        /// </summary>
        /// <value>
        /// The ISO 3166-1 country code.
        /// </value>
        public string Iso_3166_1 { get; set; }

        /// <summary>
        /// Gets or sets the certification.
        /// </summary>
        /// <value>
        /// The certification.
        /// </value>
        public string Certification { get; set; }
    }
}
