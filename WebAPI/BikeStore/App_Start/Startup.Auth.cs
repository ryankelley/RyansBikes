﻿using System;
using BikeStore.Models;
using BikeStore.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace BikeStore
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }

        static Startup()
        {
            String PublicClientId = "self";
            UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>(new BikeContext()));
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(24),
                AllowInsecureHttp = true
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
         
    }
}