using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Movies.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieViewModel : IMovieItem, INotifyPropertyChanged
    {
        string Path { get; }
        string Id { get; }
        string SetName { get; set; }
        IMovieSelectionViewModel Selection { get; }
    }
}
