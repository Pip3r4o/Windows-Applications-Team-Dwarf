namespace JustQuest.UI.DataModels.QuestDataModels
{
    public class QuestPageViewModel : ViewModelBase, IPageViewModel
    {
        public QuestPageViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title => "All Quests";

        public IContentViewModel ContentViewModel { get; set; }
    }
}
