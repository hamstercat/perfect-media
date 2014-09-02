using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Actors
{
    public interface IActorViewModelFactory
    {
        IImageViewModel GetImage(bool horizontalAlignement);
    }
}