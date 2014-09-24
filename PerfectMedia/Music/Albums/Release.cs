using System;

namespace PerfectMedia.Music.Albums
{
    public class Release
    {
        public string Id { get; set; }
        public string Title { get; set; }
        // Can be either YYYY-mm-dd or YYYY
        public string Date { get; set; }

        public int Year
        {
            get
            {
                string substring = Date.Substring(0, 4);
                return int.Parse(substring);
            }
        }

        public DateTime? DateTime
        {
            get
            {
                DateTime dateTime;
                if (System.DateTime.TryParse(Date, out dateTime))
                {
                    return dateTime;
                }
                return null;
            }
        }
    }
}
