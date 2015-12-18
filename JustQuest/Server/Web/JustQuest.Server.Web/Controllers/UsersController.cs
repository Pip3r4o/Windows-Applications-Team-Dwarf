namespace JustQuest.Server.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.AspNet.Identity;
    using Models;

    public class UsersController : ApiController
    {
        private IApplicationData data;

        public UsersController(IApplicationData data)
        {
            this.data = data;
        }

        public UsersController()
            : this(new ApplicationData())
        {
        }
        
        [Authorize]
        [Route("~/api/users/myquests")]
        [HttpGet]
        public IHttpActionResult GetMyQuests()
        {
            var currentUserId = User.Identity.GetUserId();
            var user = this.data.Users.All().FirstOrDefault(x => x.Id == currentUserId);

            var result = user.Quests.AsQueryable()
                .OrderByDescending(x => x.NumberOfRemainingCorrectGuesses)
                .ProjectTo<QuestResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Route("~/api/users/leaderboard")]
        [HttpGet]
        public IHttpActionResult GetLeaderboard()
        {
            var users = this.data.Users.All()
                .OrderByDescending(x => x.Rupees)
                .Take(20)
                .ProjectTo<SimpleUserResponseModel>()
                .ToList();

            return this.Ok(users);
        }
    }
}