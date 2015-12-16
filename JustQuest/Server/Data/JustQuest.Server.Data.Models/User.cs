namespace JustQuest.Server.Data.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    public class User : IdentityUser
    {
        private ICollection<Quest> quests;

        public User()
        {
            this.quests = new HashSet<Quest>();
            this.Rupees = 100;
        }

        public int Rupees { get; set; }

        public virtual ICollection<Quest> Quests
        {
            get { return this.quests; }
            set { this.quests = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
