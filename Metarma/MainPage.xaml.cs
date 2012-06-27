using System;
using System.Threading.Tasks;

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
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Metarma
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        void InitHandlers()
        {
            //Windows.Storage.ApplicationData.Current.DataChanged +=
              // new TypedEventHandler<Windows.Storage.ApplicationData, MainPage>(DataChangeHandler);
        }

        void DataChangeHandler(Windows.Storage.ApplicationData appData, object o)
        {
            // TODO: Refresh your data
        }


        public MainPage()
        {
            this.InitHandlers();
            this.InitializeComponent();

            var settingspane = Windows.UI.ApplicationSettings.SettingsPane.GetForCurrentView();

            //settingspane.CommandsRequested += settingspane_CommandsRequested;
            GridView sp = (GridView)FindName("MainGrid");
            sp.ItemsSource = Stations.Instance.StationsList;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
 
   
        }

 
        private void AddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddStation));
		}

        private void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GridView sp = (GridView)FindName("MainGrid");
            if (sp.SelectedIndex != -1)
            {
                // delete the one at the index
                Preferences.Instance.GetStationsList().RemoveAt(sp.SelectedIndex);
                Stations.Instance.StationsList.RemoveAt(sp.SelectedIndex);
                Preferences.Instance.SaveToRegistry();
            }
            this.BottomAppBar.IsOpen = false;
        }
    }
}
