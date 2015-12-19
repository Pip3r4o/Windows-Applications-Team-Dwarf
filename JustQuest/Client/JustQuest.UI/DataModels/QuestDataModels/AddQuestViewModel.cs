namespace JustQuest.UI.DataModels.QuestDataModels
{
    public class AddQuestViewModel : ViewModelBase, IPageViewModel
    {
        public AddQuestViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title
        {
            get
            {
                return "Add new Quest";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}
