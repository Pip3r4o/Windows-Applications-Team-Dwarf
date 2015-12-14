namespace JustQuest.Server.Data
{
    using Models;
    using Repositories;

    public interface IApplicationData
    {
        IRepository<User> Users { get; set; }

        IRepository<Quest> Quests { get; set; }

        IRepository<Hint> Hints { get; set; }

        void SaveChanges();
    }
}
