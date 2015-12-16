using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JustQuest.Server.Web.Startup))]

namespace JustQuest.Server.Web
{
    using System.Reflection;
    using App_Start;
    using Microsoft.Owin.Cors;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DatabaseConfig.Initialize();

            AutoMapperConfig.RegisterMappings();

            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
        }
    }
}
