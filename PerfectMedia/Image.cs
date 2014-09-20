namespace PerfectMedia
{
    [Equals]
    public class Image
    {
        public string Url { get; set; }
        public double? Rating { get; set; }
        public string Description { get; set; }
        public double WidthRatio { get; set; }
        public double HeightRatio { get; set; }
    }
}
