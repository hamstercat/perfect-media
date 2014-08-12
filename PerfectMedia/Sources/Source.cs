using System.Xml.Serialization;

namespace PerfectMedia.Sources
{
    /// <summary>
    /// Sources for a specific source type.
    /// </summary>
    [XmlRoot]
    public class Source
    {
        /// <summary>
        /// Gets or sets the type of the source.
        /// </summary>
        /// <value>
        /// The type of the source.
        /// </value>
        public SourceType SourceType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is root.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is root; otherwise, <c>false</c>.
        /// </value>
        public bool IsRoot { get; set; }

        /// <summary>
        /// Gets or sets the folder path.
        /// </summary>
        /// <value>
        /// The folder path.
        /// </value>
        public string Folder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> class.
        /// </summary>
        public Source()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> class.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="isRoot">if set to <c>true</c> [is root].</param>
        /// <param name="folder">The folder path.</param>
        public Source(SourceType sourceType, bool isRoot, string folder)
        {
            SourceType = sourceType;
            IsRoot = isRoot;
            Folder = folder;
        }
    }
}
