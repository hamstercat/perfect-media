﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerfectMedia
{
    public class ActorMetadata
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "role")]
        public string Role { get; set; }

        [XmlElement(ElementName = "thumb")]
        public string Thumb { get; set; }

        [XmlIgnore]
        public string ThumbPath { get; set; }

        public static string GetActorThumbPath(string tvShowPath, string actorName)
        {
            string actorsFolder = GetActorsFolder(tvShowPath);
            string fileName = GetActorThumnbnailFileName(actorName);
            return Path.Combine(actorsFolder, fileName);
        }

        public static string GetActorsFolder(string tvShowPath)
        {
            return Path.Combine(tvShowPath, ".actors");
        }

        public static string GetActorThumnbnailFileName(string actorName)
        {
            string fileName = actorName
                .Replace(" ", "_")
                .Replace("\t", "");
            return fileName + ".jpg";
        }
    }
}