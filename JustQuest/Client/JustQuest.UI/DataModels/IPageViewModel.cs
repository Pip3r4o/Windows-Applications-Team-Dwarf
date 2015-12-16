namespace JustQuest.UI.DataModels
{
    internal interface IPageViewModel
    {
        string Title { get; }

        IContentViewModel ContentViewModel { get; set; }
    }
}