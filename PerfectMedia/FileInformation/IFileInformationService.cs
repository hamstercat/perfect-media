
namespace PerfectMedia.FileInformation
{
    /// <summary>
    /// Returns details about streams found in video and audio files.
    /// </summary>
    public interface IFileInformationService
    {
        /// <summary>
        /// Gets the video file information.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        VideoFileInformation GetVideoFileInformation(string file);
    }
}
