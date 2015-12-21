using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JustQuest.UI
{
    using System.Collections.Generic;
    using DataModels;
    using DataModels.QuestDataModels;
    using Helpers;
    using Newtonsoft.Json;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly HttpRequester httpClient;

        public MainPage()
        {
            this.InitializeComponent();

            this.httpClient = new HttpRequester();

            this.DataContext = new MainPageModel { ActiveQuests = 0 };

            GetDataContextFromServer();
        }

        private async void GetDataContextFromServer()
        {
            var response = await this.httpClient.GetData("api/quests/count");

            if (response.IsSuccessStatusCode)
            {
                var responseAsString = await response.Content.ReadAsStringAsync();

                var count = int.Parse(responseAsString);

                this.DataContext = new MainPageModel { ActiveQuests = count };
            }
        }

        private void Register_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register));
        }

        private void Icon2_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
        }

        private void Icon3_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
        }

        private void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
