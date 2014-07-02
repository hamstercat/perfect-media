﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    [Equals]
    public class Audio
    {
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        [XmlElement(ElementName = "channels")]
        public int NumberOfChannels { get; set; }

        [XmlElement(ElementName = "codec")]
        public string Codec { get; set; }
    }
}
