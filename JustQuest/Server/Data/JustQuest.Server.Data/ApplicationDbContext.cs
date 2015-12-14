namespace JustQuest.Server.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        private const string localsqldb = "DefaultConnection";

        public ApplicationDbContext()
            : base(localsqldb)
        {

        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }

        public IDbSet<Quest> Quests { get; set; }

        public IDbSet<Hint> Hints { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
