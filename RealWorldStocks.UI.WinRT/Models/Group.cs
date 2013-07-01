using System.Collections.ObjectModel;

namespace RealWorldStocks.UI.Models
{
    public class Group
    {
        public string Title { get; set; }

        public Group(string title)
        {
            Title = title;
        }
    }

    public class Group<T> : Group
    {
        public Group(string title) : base(title)
        {
        }

        public ObservableCollection<T> Items { get; set; }
    }
}