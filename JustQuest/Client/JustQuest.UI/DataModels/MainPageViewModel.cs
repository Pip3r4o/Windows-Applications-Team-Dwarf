namespace JustQuest.UI.DataModels
{
    public class MainPageViewModel : ViewModelBase, IPageViewModel
    {
        public MainPageViewModel(IContentViewModel model)
        {
            this.ContentViewModel = model;
        }

        public string Title => "Main Page";

        public IContentViewModel ContentViewModel { get; set; }
    }
}