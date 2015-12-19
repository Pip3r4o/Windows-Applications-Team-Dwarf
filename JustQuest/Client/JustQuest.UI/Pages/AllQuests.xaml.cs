using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace JustQuest.UI.Pages
{
    using System.Threading.Tasks;
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
    }
}
