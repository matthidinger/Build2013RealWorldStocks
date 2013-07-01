#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Controls;
#endif

namespace RealWorldStocks.UI.Controls
{
    [TemplateVisualState(Name = "Positive", GroupName = "PriceStates")]
    [TemplateVisualState(Name = "Negative", GroupName = "PriceStates")]
    public class PriceChangeArrow : Control
    {
        public PriceChangeArrow()
        {
            DefaultStyleKey = typeof(PriceChangeArrow);
        }

#if NETFX_CORE
        protected override void OnApplyTemplate()
#else
        public override void OnApplyTemplate()
#endif
        {
            LayoutUpdated += PriceChangeArrow_LayoutUpdated;
            base.OnApplyTemplate();
        }


#if NETFX_CORE
        void PriceChangeArrow_LayoutUpdated(object sender, object e)
#else
        void PriceChangeArrow_LayoutUpdated(object sender, System.EventArgs e)
#endif
        {
            ChangeVisualState(true);
        }

        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(decimal), typeof(PriceChangeArrow), new PropertyMetadata(default(decimal), PriceChanged));


        private static void PriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PriceChangeArrow) d).ChangeVisualState(true);
        }

        public decimal Price
        {
            get { return (decimal)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }


        private string CurrentPriceVisualState
        {
            get
            {
                if (Price >= 0)
                    return "Positive";
                
                return "Negative";
            }
        }

        private void ChangeVisualState(bool useTransitions)
        {
            VisualStateManager.GoToState(this, CurrentPriceVisualState, useTransitions);
        }
    }
}