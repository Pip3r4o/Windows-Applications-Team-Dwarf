namespace JustQuest.UI.Pages
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Data;
    using DataModels;
    using DataModels.QuestDataModels;
    using Helpers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllQuests : Page
    {
        private readonly HttpRequester httpClient;

        public AllQuests()
        {
            this.InitializeComponent();

            this.httpClient = new HttpRequester();

            SetDataContextFromRemoteData();
        }

        public async void SetDataContextFromRemoteData()
        {
            var credentials = await SQLiteData.GetUserCredentials();

            var token = credentials.Token ?? "";

            // Display only other users' quests
            var response = await this.httpClient.GetDataAuthorize("api/quests", token);

            if (response.IsSuccessStatusCode)
            {
                var questsAsString = await response.Content.ReadAsStringAsync();

                var questsViewModel = new QuestViewModel();

                questsViewModel.Quests = JsonConvert.DeserializeObject<List<Quest>>(questsAsString);

                this.DataContext = new QuestPageViewModel(questsViewModel);
            }
            else
            {
                // TODO:
            }

        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer sv = sender as ScrollViewer;

            if (sv.VerticalOffset == 0)
            {
                scrollViewer.DirectManipulationCompleted += ScrollViewer_DirectManipulationCompleted;

                VisualStateManager.GoToState(this, "Refreshing", false);
            }
        }

        private void ScrollViewer_DirectManipulationCompleted(object sender, object e)
        {
            scrollViewer.DirectManipulationCompleted -= ScrollViewer_DirectManipulationCompleted;
            UpdateFeed();
        }

        private void UpdateFeed()
        {
            scrollViewer.ChangeView(null, 0, null, true);
            VisualStateManager.GoToState(this, "PullToRefresh", false);
        }

        private void Grid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var quest = ((sender as Grid).DataContext);

            this.Frame.Navigate(typeof(CurrentQuestPage), quest);

        }
    }
}
