using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public class ImdbMovieSynopsisService : IMovieSynopsisService
    {
        private readonly IRestApiService _restApiService;

        public ImdbMovieSynopsisService(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        public MovieSynopsis GetSynopsis(string movieId)
        {
            string url = string.Format("title/{0}/", movieId);
            string moviePageContent = _restApiService.Get(url);
            return ParseMoviePageContent(moviePageContent);
        }

        private MovieSynopsis ParseMoviePageContent(string moviePageContent)
        {
            MovieSynopsis synopsis = new MovieSynopsis();
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(moviePageContent);

            synopsis.Outline = ExtractOutline(htmlDocument);
            synopsis.Plot = ExtractPlot(htmlDocument);

            synopsis.Tagline = ExtractTagline(moviePageContent);
            return synopsis;
        }

        private static string ExtractOutline(HtmlDocument htmlDocument)
        {
            HtmlNode outlineNode = htmlDocument.DocumentNode.SelectSingleNode("//p[@itemprop='description']");
            if (outlineNode != null)
            {
                return outlineNode.InnerText.Trim();
            }
            return null;
        }

        private static string ExtractPlot(HtmlDocument htmlDocument)
        {
            HtmlNode plotNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@itemprop='description']/p");
            if (plotNode != null)
            {
                Match plotMatch = Regex.Match(plotNode.InnerHtml, @"\s*(.*)\s*<em");
                if (plotMatch.Success)
                    return plotMatch.Groups[1].Value.Trim();
            }
            return null;
        }

        private string ExtractTagline(string moviePageContent)
        {
            Match taglineMatch = Regex.Match(moviePageContent, @">Taglines:</h4>\s*(.*)\s*<span class=""see-more");
            if (taglineMatch.Success)
            {
                return taglineMatch.Groups[1].Value.Trim();
            }
            return null;
        }
    }
}
