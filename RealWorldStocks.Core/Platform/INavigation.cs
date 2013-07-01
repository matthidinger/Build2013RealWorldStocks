namespace RealWorldStocks.Core.Platform
{
    public interface INavigation
    {
        void NavigateTo(string pageName, object parameter = null, string queryString = null);
        void NavigateBack();
    }
}