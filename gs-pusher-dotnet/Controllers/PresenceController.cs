using gs_pusher_dotnet.Models;
using PusherServer;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace gs_pusher_dotnet.Controllers
{
    public class PresenceController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.PusherAppKey = ConfigurationManager.AppSettings["PusherAppKey"];
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(AuthenticateModel model)
        {
            var pusher = new Pusher(
                ConfigurationManager.AppSettings["PusherAppId"],
                ConfigurationManager.AppSettings["PusherAppKey"],
                ConfigurationManager.AppSettings["PusherAppSecret"]);

            // TODO: implement checks to determine if the user is:
            // 1. Authenticated with the app
            // 2. Allowed to subscribe to the `channelName`
            // 3. Sanitize any additional data that has been recieved and is to be used
            // If so, proceed...

            // Hard-coded channel data for the example.
            // In a real application this would be generated based the on the current app user.
            var channelData = new PresenceChannelData()
            {
                user_id = $"user_{Convert.ToString(new Random().Next(int.MaxValue), 16)}",
                user_info = new {
                    website = "https://pusher.com",
                    company = "Pusher",
                    job_title = "Developer Evangelist",
                    is_active = true,
                    email = "jack@pusher.com"
                }
            };
            IAuthenticationData authData = pusher.Authenticate(model.channel_name, model.socket_id, channelData);
            return Json(authData);
        }
    }
}