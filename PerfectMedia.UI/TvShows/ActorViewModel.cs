using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows
{
    public class ActorViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _role;
        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                OnPropertyChanged("Role");
            }
        }

        private string _thumb;
        public string ThumbUrl
        {
            get
            {
                return _thumb;
            }
            set
            {
                _thumb = value;
                OnPropertyChanged("ThumbUrl");
            }
        }

        private string _thumbPath;
        public string ThumbPath
        {
            get
            {
                return _thumbPath;
            }
            set
            {
                _thumbPath = value;
                OnPropertyChanged("ThumbPath");
            }
        }
    }
}
