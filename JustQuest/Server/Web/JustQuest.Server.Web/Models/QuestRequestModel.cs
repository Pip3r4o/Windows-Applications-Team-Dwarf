namespace JustQuest.Server.Web.Models
{
    using System.Collections.Generic;

    public class QuestRequestModel
    {
        public string Name { get; set; }

        public string Task { get; set; }

        public string PossibleAnswers { get; set; }

        public ICollection<HintRequestModel> Hints { get; set; }
    }
}
