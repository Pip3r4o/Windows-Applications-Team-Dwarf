namespace JustQuest.UI.DataModels.LeaderboardDataModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Helpers;

    public class LeaderboardViewModel : ViewModelBase, IContentViewModel
    {
        private ICollection<Leaderboard> leaderboardEntries;

        public LeaderboardViewModel()
        {
        }

        public ICollection<Leaderboard> LeaderboardEntries
        {
            get
            {
                if (this.leaderboardEntries == null)
                {
                    this.leaderboardEntries = new ObservableCollection<Leaderboard>();
                }

                return this.leaderboardEntries;
            }
            set
            {
                if (this.leaderboardEntries == null)
                {
                    this.leaderboardEntries = new ObservableCollection<Leaderboard>();
                }

                this.leaderboardEntries.Clear();

                foreach (var questToAdd in value)
                {
                    this.leaderboardEntries.Add(questToAdd);
                }
            }
        }
    }
}
