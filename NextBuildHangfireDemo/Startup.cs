﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NextBuildHangfireDemo.Startup))]
namespace NextBuildHangfireDemo
{
    using Hangfire;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage("MailerDb");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
