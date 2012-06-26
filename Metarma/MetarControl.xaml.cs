using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Metarma
{
    public sealed partial class MetarControl : UserControl
    {
        private Metar metar_;

        public MetarControl()
        {
            this.InitializeComponent();
        }

        public void SetMetar(Metar inMetar)
        {
            metar_ = inMetar;

            TextBlock tb = (TextBlock)FindName("StationName");
            tb.SetValue(TextBlock.TextProperty, metar_.GetStation());

            TextBlock metarControl = (TextBlock)FindName("Metar");
            if (!metar_.IsBad())
            {
                metarControl.SetValue(TextBlock.TextProperty, metar_.GetMetarOnly());
                //metarControl.SetValue(TextBlock.TextProperty, metar_.GetRawMetar());
                metarControl.SetValue(TextBlock.VisibilityProperty, Visibility.Visible);
            }
        }

    }
}
