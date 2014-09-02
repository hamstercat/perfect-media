using PerfectMedia.UI.Images;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.Actors
{
    [ImplementPropertyChanged]
    public class ActorViewModel : BaseViewModel, IActorViewModel
    {
        [LocalizedRequired]
        public string Name { get; set; }

        [LocalizedRequired]
        public string Role { get; set; }

        public string ThumbUrl { get; set; }
        public IImageViewModel ThumbPath { get; private set; }

        public ActorViewModel(IImageViewModel newImageViewModel)
        {
            ThumbPath = newImageViewModel;
        }
    }
}
