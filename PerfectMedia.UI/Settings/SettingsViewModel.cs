using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.Movies;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.Settings
{
    [ImplementPropertyChanged]
    public class SettingsViewModel : BaseViewModel, ISettingsViewModel
    {
        private readonly IGeneralSettings _generalSettings;
        private readonly IMovieSettingsService _movie;

        [FolderExists]
        public string MovieSetArtworkFolder { get; set; }

        public string Language { get; set; }
        public ICommand SaveCommand { get; private set; }

        public SettingsViewModel(IGeneralSettings generalSettings, IMovieSettingsService movie)
        {
            _generalSettings = generalSettings;
            _movie = movie;
            SaveCommand = new SaveCommand(this);
        }

        public async Task Initialize()
        {
            MovieSetArtworkFolder = await _movie.GetMovieSetArtworkFolder();
            Language = _generalSettings.GetLanguage();
        }

        public void Save()
        {
            _movie.SetMovieSetArtworkFolder(MovieSetArtworkFolder);
            _generalSettings.SetLanguage(Language);
        }
    }
}