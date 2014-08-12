using System.Text.RegularExpressions;
using Anotar.Log4Net;
using HtmlAgilityPack;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// Finds synopsis information for a movie on imdb.com.
    /// </summary>
    public class ImdbMovieSynopsisService : IMovieSynopsisService
    {
        private readonly IRestApiService _restApiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImdbMovieSynopsisService"/> class.
        /// </summary>
        /// <param name="restApiService">IMDB API service.</param>
        public ImdbMovieSynopsisService(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        /// <summary>
        /// Gets the synopsis.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        [LogToErrorOnException]
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
