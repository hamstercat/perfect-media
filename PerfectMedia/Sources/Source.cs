using System.Xml.Serialization;

namespace PerfectMedia.Sources
{
    [XmlRoot]
    public class Source
    {
        public SourceType SourceType { get; set; }
        public bool IsRoot { get; set; }
        public string Folder { get; set; }

        public Source()
        { }

        public Source(SourceType sourceType, bool isRoot, string folder)
        {
            SourceType = sourceType;
            IsRoot = isRoot;
            Folder = folder;
        }
    }
}
