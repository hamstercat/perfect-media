using PerfectMedia.UI.Images;
using PropertyChanged;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public class ActorViewModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string ThumbUrl { get; set; }
        public IImageViewModel ThumbPath { get; private set; }

        public ActorViewModel(IImageViewModel newImageViewModel)
        {
            ThumbPath = newImageViewModel;
        }
    }
}
