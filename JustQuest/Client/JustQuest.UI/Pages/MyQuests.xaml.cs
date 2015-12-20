namespace JustQuest.UI.Pages
{
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;
    using Data;
    using DataModels.QuestDataModels;
    using Helpers;
    using Newtonsoft.Json;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyQuests : Page
    {
        private readonly HttpRequester httpClient;

        public MyQuests()
        {
            this.InitializeComponent();

            this.httpClient = new HttpRequester();

            SetDataContextFromRemoteData();
        }

        public async void SetDataContextFromRemoteData()
        {
            var credentials = await SQLiteData.GetUserCredentials();

            var token = credentials.Token ?? "";

            // Display only current users' quests
            var response = await this.httpClient.GetDataAuthorize("api/users/myquests", token);

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
    }
}
