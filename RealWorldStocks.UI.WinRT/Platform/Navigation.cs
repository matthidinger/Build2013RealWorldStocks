using System;
using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.UI.Platform
{
    public class Navigation : INavigation
    {
        public void NavigateTo(string pageName, object parameter = null, string queryString = null)
        {
            var type = Type.GetType(String.Format("RealWorldStocks.UI.Views.{0}", pageName));
            App.RootFrame.Navigate(type, parameter ?? pageName);
        }

        public void NavigateBack()
        {
            App.RootFrame.GoBack();
        }

    }
}