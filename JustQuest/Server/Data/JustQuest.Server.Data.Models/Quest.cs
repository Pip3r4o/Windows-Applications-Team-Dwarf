namespace JustQuest.Server.Data.Models
{
    using System.Collections.Generic;

    public class Quest
    {
        private ICollection<Hint> hints;

        public Quest()
        {
            this.hints = new HashSet<Hint>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Task { get; set; }

        // colon ";" separated
        // public string PossibleAnswers { get; set; }

        public ICollection<string> PossibleAnswers { get; set; }

        public ICollection<Hint> Hints { get { return this.hints; } set { this.hints = value; } }
    }
}
