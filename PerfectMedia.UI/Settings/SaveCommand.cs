using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PerfectMedia.UI.Settings
{
    public class SaveCommand : ICommand
    {
        private readonly ISettingsViewModel _settings;

        public event EventHandler CanExecuteChanged;

        public SaveCommand(ISettingsViewModel settings)
        {
            _settings = settings;
            _settings.PropertyChanged += SettingsPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return !_settings.HasErrors;
        }

        public void Execute(object parameter)
        {
            _settings.Save();
        }

        private void SettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}