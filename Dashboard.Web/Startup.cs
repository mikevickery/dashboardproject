﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dashboard.Web.Startup))]
namespace Dashboard.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
