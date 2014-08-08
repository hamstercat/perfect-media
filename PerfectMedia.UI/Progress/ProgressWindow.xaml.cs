using System.Windows;

namespace PerfectMedia.UI.Progress
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window, IProgressIndicator
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        public void Show(IProgressManagerViewModel progressManager)
        {
            DataContext = progressManager;
            Show();
        }
    }
}
