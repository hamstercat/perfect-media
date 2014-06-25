using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    public class VideoFileInformation
    {
        [XmlElement(ElementName = "streamdetails")]
        public StreamDetails StreamDetails { get; set; }

        public bool ShouldSerializeStreamDetails()
        {
            return StreamDetails != null;
        }
    }
}
