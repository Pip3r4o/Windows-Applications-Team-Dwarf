namespace JustQuest.Server.Web.Models
{
    using Contracts;
    using Data.Models;

    public class SimpleUserResponseModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public int Rupees { get; set; }
    }
}
