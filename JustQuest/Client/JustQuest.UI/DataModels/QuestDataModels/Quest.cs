namespace JustQuest.UI.DataModels.QuestDataModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using HintDataModels;

    public class Quest : ViewModelBase
    {
        public Quest()
        : this(string.Empty, string.Empty, string.Empty, 0)
        {

        }


        public Quest(Quest quest)
      : this(quest.Name, quest.Task, quest.PossibleAnswers, quest.PointsAward)
        {

        }

        public Quest(string name, string task, string possibleAnswers, int pointsAward)
        {
            this.Name = name;
            this.Task = task;
            this.PossibleAnswers = possibleAnswers;
            this.Hints = new ObservableCollection<Hint>();
            this.PointsAward = pointsAward;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Task { get; set; }

        public string PossibleAnswers { get; set; }

        public int PointsAward { get; set; }

        public ICollection<Hint> Hints { get; set; }

        public void AddHint(Hint hint)
        {
            this.Hints.Add(hint);
        }
    }
}
