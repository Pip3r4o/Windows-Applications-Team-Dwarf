namespace JustQuest.Server.Data
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

    public class ApplicationData : IApplicationData
    {
        private IApplicationDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public ApplicationData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public ApplicationData()
            : this(new ApplicationDbContext())
        {
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
            set { }
        }

        public IRepository<Quest> Quests
        {
            get { return this.GetRepository<Quest>(); }
            set { }
        }

        public IRepository<Hint> Hints
        {
            get { return this.GetRepository<Hint>(); }
            set { }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
