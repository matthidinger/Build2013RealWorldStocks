using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;

namespace RealWorldStocks.UI.Controls
{
    public class LaunchBrowserBehavior : Behavior<ButtonBase>
    {
        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register  ("Url", typeof (string), typeof (LaunchBrowserBehavior), null);

        public string Url
        {
            get { return (string) GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += OnClick;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var task = new WebBrowserTask {Uri = new Uri(Url, UriKind.Absolute)};
            task.Show();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Click -= OnClick;
        }
    }
}