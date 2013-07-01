using System;
using System.Windows.Input;
using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.Core.Commands
{
    public class ViewStockDetailsCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var symbol = parameter as string;
            if (symbol != null)
            {
                PlatformAdapter.Current.Navigation.NavigateTo(
                    pageName: "StockDetailsView",
                    queryString: "symbol=" + symbol,
                    parameter: symbol);
            }
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }
}