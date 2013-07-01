using System;
using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.UI.Platform
{
    public class Navigation : INavigation
    {
        public void NavigateTo(string pageName, object parameter = null, string queryString = null)
        {
            App.RootFrame.Navigate(new Uri(String.Format("/Views/{0}.xaml?{1}", pageName, queryString), UriKind.Relative));
        }

        public void NavigateBack()
        {
            App.RootFrame.GoBack();
        }
    }
}