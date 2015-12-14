using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JustQuest.Server.Web.Startup))]

namespace JustQuest.Server.Web
{
    using Microsoft.Owin.Cors;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
        }
    }
}
