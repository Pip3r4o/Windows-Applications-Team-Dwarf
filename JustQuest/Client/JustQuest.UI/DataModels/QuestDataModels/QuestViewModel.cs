using JustQuest.UI.Data;
using JustQuest.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JustQuest.UI.DataModels
{
    public class QuestViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand addQuestCommand;
        private readonly HttpRequester httpClient;

        public ICommand AddQuest
        {
            get
            {
                if (this.addQuestCommand == null)
                {

                    this.addQuestCommand = new DelegateCommand<Quest>(async (quest) =>
                    {
                        var userCredentials = await SQLiteData.GetUserCredentials();

                        var token = userCredentials.Token ?? "";

                        // TODO:
                        object questFormDetails = null;

                        var response = await httpClient.PostData(questFormDetails, "api/quests", token);
                    });
                }
                return this.addQuestCommand;
            }

        }

    }
}
