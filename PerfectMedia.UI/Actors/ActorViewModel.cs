using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.Actors
{
    [ImplementPropertyChanged]
    public class ActorViewModel : BaseViewModel, IActorViewModel
    {
        [LocalizedRequired]
        public IPropertyViewModel<string> Name { get; set; }

        [LocalizedRequired]
        public IPropertyViewModel<string> Role { get; set; }

        public string ThumbUrl { get; set; }
        public IImageViewModel ThumbPath { get; private set; }

        public ActorViewModel(IImageViewModel newImageViewModel)
        {
            ThumbPath = newImageViewModel;
            Name = new RequiredPropertyDecorator<string>(new PropertyViewModel<string>());
            Role = new RequiredPropertyDecorator<string>(new PropertyViewModel<string>());
        }

        public void Initialize(string name, string role)
        {
            Name.Value = name;
            Name.Save();
            Role.Value = role;
            Role.Save();
        }
    }
}
