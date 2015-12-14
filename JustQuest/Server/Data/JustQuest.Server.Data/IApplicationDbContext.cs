using System.Data.Entity;
namespace JustQuest.Server.Data
{
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IApplicationDbContext
    {
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<User> Users { get; set; }
        
        IDbSet<Quest> Quests { get; set; }

        IDbSet<Hint> Hints { get; set; }

        void SaveChanges();
    }
}
