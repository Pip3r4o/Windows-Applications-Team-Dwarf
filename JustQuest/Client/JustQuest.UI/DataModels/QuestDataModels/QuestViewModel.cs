namespace JustQuest.UI.DataModels.QuestDataModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Data;
    using Extensions;
    using Helpers;
    using HintDataModels;
    using Newtonsoft.Json;

    public class QuestViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand addQuestCommand;
        private ICommand addHintCommand;
        public static List<Hint> hintsToAdd;
        private ObservableCollection<Hint> hints;
        private ICollection<Quest> quests;
        private readonly HttpRequester httpClient;

        public QuestViewModel()
        {
            httpClient = new HttpRequester();
            hintsToAdd = new List<Hint>();
        }

        public ICollection<Quest> Quests
        {
            get
            {
                if (this.quests == null)
                {
                    this.quests = new ObservableCollection<Quest>();
                }

                return this.quests;
            }
            set
            {
                if (this.quests == null)
                {
                    this.quests = new ObservableCollection<Quest>();
                }

                this.quests.Clear();

                foreach (var questToAdd in value)
                {
                    this.quests.Add(questToAdd);
                }
            }
        } 

        public ICollection<Hint> Hints
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
                        var response = await httpClient.PostData(quest, "api/Quests", token);
                        hintsToAdd.Clear();
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
                        ((Window.Current.Content as AppShell).AppFrame as Frame).GoBack();
                    });
                    
                }
                return this.addHintCommand;
            }

        }
    }
}
