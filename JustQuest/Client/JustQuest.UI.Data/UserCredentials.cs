using SQLite.Net.Attributes;

namespace JustQuest.UI.Data
{
    public class UserCredentials
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }
    }
}