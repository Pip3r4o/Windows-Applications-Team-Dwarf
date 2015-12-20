namespace JustQuest.UI.Pages
{
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;
    using DataModels.LeaderboardDataModels;
    using DataModels.QuestDataModels;
    using Helpers;
    using Newtonsoft.Json;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Leaderboards : Page
    {
        private readonly HttpRequester httpClient;

        public Leaderboards()
        {
            this.InitializeComponent();

            this.httpClient = new HttpRequester();

            SetDataContextFromRemoteData();
        }

        public async void SetDataContextFromRemoteData()
        {
            // Display only other users' quests
            var response = await this.httpClient.GetData("api/users/leaderboard");

            if (response.IsSuccessStatusCode)
            {
                var leaderboardAsString = await response.Content.ReadAsStringAsync();

                var leaderboardViewModel = new LeaderboardViewModel();

                leaderboardViewModel.LeaderboardEntries = JsonConvert.DeserializeObject<List<Leaderboard>>(leaderboardAsString);

                this.DataContext = new LeaderboardPageViewModel(leaderboardViewModel);
            }
            else
            {
                // TODO:
            }
        }
    }
}
