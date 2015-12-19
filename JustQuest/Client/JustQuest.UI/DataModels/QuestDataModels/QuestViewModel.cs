using JustQuest.UI.Data;
using JustQuest.UI.Extensions;
using JustQuest.UI.Helpers;
using Newtonsoft.Json;
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
        private ICommand addHintCommand;
        public static List<Hint> hintsToAdd = new List<Hint>();
        public ObservableCollection<Hint> hints;
        private readonly HttpRequester httpClient;

        public IEnumerable<Hint> Hints
        {
            get
            {
                if (this.hints == null)
                {
                    this.hints = new ObservableCollection<Hint>();
                }

                return this.hints;
            }
            set
            {
                if (this.hints == null)
                {
                    this.hints = new ObservableCollection<Hint>();
                }

                this.hints.Clear();
                foreach (var hintToAdd in hintsToAdd)
                {
                    this.hints.Add(hintToAdd);
                }
                    value.ForEach(this.hints.Add);
            }
        }

        public ICommand AddQuest
        {
            get
            {
                if (this.addQuestCommand == null)
                {

                    this.addQuestCommand = new DelegateCommand<Quest>(async (quest) =>
                    {
                        foreach (var hint in hintsToAdd)
                        {
                            quest.Hints.Add(hint);
                        }
                        var userCredentials = await SQLiteData.GetUserCredentials();

                        var token = userCredentials.Token ?? "";

                        // TODO:
                        object questFormDetails = JsonConvert.SerializeObject(quest);

                        var response = await httpClient.PostData(questFormDetails, "api/Quests", token);
                    });
                }
                return this.addQuestCommand;
            }

        }


        public ICommand AddHint
        {
            get
            {
                if (this.addHintCommand == null)
                {

                    this.addHintCommand = new DelegateCommand<Hint>((hint) =>
                    {
                        hintsToAdd.Add(hint);
                    });
                }
                return this.addHintCommand;
            }

        }
    }
}
