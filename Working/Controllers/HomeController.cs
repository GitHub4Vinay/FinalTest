using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;

namespace Working.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void TwitterCallback(string oauth_token, string oauth_verifier)
        {
            var requestToken = new OAuthRequestToken { Token = oauth_token };

            string Key = "iUD7K2zDZJ8dY0Q10RtFON4ur";
            string Secret = "rms13aB3voQYlFBFTcwwGviGK3cs7hheMN2nnlb5vryLeA4i9t";

            try
            {
                TwitterService service = new TwitterService(Key, Secret);

                OAuthAccessToken accessToken = service.GetAccessToken(requestToken, oauth_verifier);

                service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);

                VerifyCredentialsOptions option = new VerifyCredentialsOptions();

                TwitterUser user = service.VerifyCredentials(option);
                service.SendTweet(new SendTweetOptions { Status = "Hi  Vinay", });
                TempData["Status"] = user.ScreenName;
                //return View();
            }
            catch
            {
                throw;
            }

        }
        //http://localhost:53914/
        public ActionResult TwitterAuth()
        {
            string Key = "iUD7K2zDZJ8dY0Q10RtFON4ur";
            string Secret = "rms13aB3voQYlFBFTcwwGviGK3cs7hheMN2nnlb5vryLeA4i9t";

            TwitterService service = new TwitterService(Key, Secret);

            OAuthRequestToken requestToken = service.GetRequestToken("http://localhost:53914/Home/TwitterCallback");

            Uri uri = service.GetAuthenticationUrl(requestToken);

            return Redirect(uri.ToString());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}