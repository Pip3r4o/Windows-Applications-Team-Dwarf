namespace JustQuest.Server.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Quest
    {
        private ICollection<Hint> hints;

        public Quest()
        {
            this.hints = new HashSet<Hint>();
            this.NumberOfRemainingCorrectGuesses = 3;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Task { get; set; }

        public int NumberOfRemainingCorrectGuesses { get; set; }

        public ICollection<string> PossibleAnswers { get; set; }

        public virtual ICollection<Hint> Hints { get { return this.hints; } set { this.hints = value; } }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
