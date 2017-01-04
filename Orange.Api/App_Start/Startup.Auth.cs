using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Orange.Api.Providers;
using Orange.Api.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Orange.Data;

namespace Orange.Api
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //Code that will allow access to the user's email once authenticated
            //You can also get the facebook token if required from the context and which can be used in the database to update information to facebook on behalf of the user.
            var facebookProvider = new FacebookAuthenticationProvider()
            {
                OnAuthenticated = (context) =>
                {
                    // Add the email id to the claim 
                    context.Identity.AddClaim(new Claim(ClaimTypes.Email, context.Email));
                    return Task.FromResult(0);

                }
            };
            var options = new FacebookAuthenticationOptions()
            {

                AppId = "827541077270473",
                AppSecret = "aa63a79f14dff2a568db23b90bbfd6d7",
                Provider = facebookProvider
            };
            options.Scope.Add("email");
            app.UseFacebookAuthentication(options);

            //app.UseFacebookAuthentication(
            //    appId: "519923214844449",
            //    appSecret: "04905ebb57fd6b1de6838fcb7e1e9515");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
