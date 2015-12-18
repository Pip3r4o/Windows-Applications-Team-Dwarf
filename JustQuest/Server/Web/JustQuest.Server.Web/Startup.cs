using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JustQuest.Server.Web.Startup))]

namespace JustQuest.Server.Web
{
    using System.Reflection;
    using App_Start;
    using AutoMapper;
    using Data.Models;
    using Microsoft.Owin.Cors;
    using Models;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DatabaseConfig.Initialize();
            
            // fallback mappings in case maps fail to register
            Mapper.CreateMap<Hint, HintResponseModel>();
            Mapper.CreateMap<Quest, QuestResponseModel>();
            Mapper.CreateMap<HintRequestModel, Hint>();
            Mapper.CreateMap<QuestRequestModel, Quest>();

            AutoMapperConfig.RegisterMappings(Assembly.Load("JustQuest.Server.Web"));

            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
        }
    }
}
