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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MetarMan2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NOAAMetarService service = new NOAAMetarService();
            StackPanel sp = (StackPanel)FindName("MainStack");
            string[] stations = { "KBFI", 
                                    "KAWO", 
                                    "KPWT", 
                                    "PABR", 
                                    "PACZ",
                                    "KIWA",
                                    "KHII",
                                "KGEU","KBLI","KCLS","KHQM","KRNT","KSHN","KATX","KNOW", "KVUO", "KTIW", "KSFF"};

            foreach( string station in stations) {
                Metar m = service.GetCurrentObs(station);
                TextBox tb = new TextBox();
                tb.SetValue(TextBox.IsReadOnlyProperty, true);
                tb.SetValue(TextBox.AcceptsReturnProperty, true);
                tb.SetValue(TextBox.WidthProperty, Double.NaN);
                if (m.IsBad())
                {
                    tb.SetValue(TextBox.TextProperty, station + " is bad");
                }
                else
                {
                    tb.SetValue(TextBox.TextProperty, m.GetRawMetar());
                }
                sp.Children.Add(tb);
            }
 

        }
    }
}
