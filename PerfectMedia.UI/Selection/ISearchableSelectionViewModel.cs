using System.Threading.Tasks;

namespace PerfectMedia.UI.Selection
{
    public interface ISearchableSelectionViewModel<T> : ISelectionViewModel<T>
    {
        string SearchTitle { get; set; }
        Task Search();
    }
}