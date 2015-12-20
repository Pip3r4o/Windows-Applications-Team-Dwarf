using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.DataModels.LeaderboardDataModels
{
    public class LeaderboardPageViewModel : ViewModelBase, IPageViewModel
    {
        public LeaderboardPageViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title => "Leaderboards";

        public IContentViewModel ContentViewModel { get; set; }
    }
}
