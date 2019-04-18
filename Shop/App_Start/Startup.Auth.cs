using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Shop.Providers;
using Shop.Models;

namespace Shop
{
    public partial class Startup
    {
        /// <summary>
        /// Initializes static members of the <see cref="Startup" /> class.
        /// </summary>
        static Startup()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        /// <summary>
        /// Gets the o auth bearer options.
        /// </summary>
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        /// <summary>
        /// The configure auth.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }



    }
}
