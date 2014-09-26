using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using PerfectMedia.ExternalApi;
using PerfectMedia.Music.Albums;
using PerfectMedia.Music.Artists;

namespace PerfectMedia.Music
{
    public class MusicBrainzMetadataUpdater : IMusicMetadataUpdater
    {
        private readonly IRestApiService _restApiService;

        private static string UserAgent
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fileVersionInfo.FileVersion;
                return string.Format("perfect-media/{0} +https://github.com/hamstercat/perfect-media", version);
            }
        }

        public MusicBrainzMetadataUpdater(IRestApiService restApiService)
        {
            _restApiService = restApiService;
            _restApiService.SetHeader("Accept", "application/xml");
            _restApiService.SetHeader("User-Agent", UserAgent);
            _restApiService.SetRateLimiter(1);
        }

        public async Task<PagedList<ArtistSummary>> FindArtists(string name, int page, int pageSize)
        {
            int offset = page * pageSize;
            string url = string.Format("/ws/2/artist?query={0}&offset={1}&limit={2}", HttpUtility.UrlEncode(name), offset, pageSize);
            string result = await _restApiService.Get(url);
            ArtistQueryMetadata metadata = DeserializeArtistQueryMetadata(result);
            return new PagedList<ArtistSummary>(metadata.Collection, page, pageSize, metadata.Collection.TotalCount);
        }

        public async Task<ArtistSummary> GetArtistMetadata(string artistId)
        {
            string url = string.Format("/ws/2/artist/{0}?inc=tags", artistId);
            ArtistSummary metadata = await _restApiService.Get<ArtistSummary>(url);
            metadata.Id = artistId;
            return metadata;
        }

        public async Task<PagedList<ReleaseGroup>> FindAlbums(string artistId, int page, int pageSize)
        {
            int offset = page * pageSize;
            string url = string.Format("/ws/2/release-group?artist={0}&offset={1}&limit={2}", artistId, offset, pageSize);
            string result = await _restApiService.Get(url);
            AlbumQueryMetadata metadata = DeserializeAlbumQueryMetadata(result);
            return new PagedList<ReleaseGroup>(metadata.Collection, page, pageSize, metadata.Collection.TotalCount);
        }

        public Task<ReleaseGroup> GetAlbum(string albumId)
        {
            string url = string.Format("/ws/2/release-group/{0}", albumId);
            return _restApiService.Get<ReleaseGroup>(url);
        }

        private ArtistQueryMetadata DeserializeArtistQueryMetadata(string xml)
        {
            XElement root = DeserializeMusicBrainzXml(xml);
            var serializer = new XmlSerializer(typeof(ArtistQueryMetadata));
            using (XmlReader xmlReader = root.CreateReader())
            {
                var metadata = (ArtistQueryMetadata)serializer.Deserialize(xmlReader);
                metadata.Collection.TotalCount = GetTotalCountAttribute(root);
                return metadata;
            }
        }

        private AlbumQueryMetadata DeserializeAlbumQueryMetadata(string xml)
        {
            XElement root = DeserializeMusicBrainzXml(xml);
            var serializer = new XmlSerializer(typeof(AlbumQueryMetadata));
            using (XmlReader xmlReader = root.CreateReader())
            {
                var metadata = (AlbumQueryMetadata)serializer.Deserialize(xmlReader);
                metadata.Collection.TotalCount = GetTotalCountAttribute(root);
                return metadata;
            }
        }

        // MusicBrainz API returns XML that doesn't play well with Restsharp's built-in deserializer
        private XElement DeserializeMusicBrainzXml(string xml)
        {
            using (TextReader stream = new StringReader(xml))
            {
                XDocument xmlDoc = XDocument.Load(stream);
                return xmlDoc.Root;
            }
        }

        private int GetTotalCountAttribute(XElement root)
        {
            XElement firstNode = root.Elements().FirstOrDefault();
            if (firstNode != null)
            {
                XAttribute attribute = firstNode.Attribute("count");
                if (attribute != null)
                {
                    int count;
                    return int.TryParse(attribute.Value, out count) ? count : 0;
                }
            }
            return 0;
        }
    }
}
