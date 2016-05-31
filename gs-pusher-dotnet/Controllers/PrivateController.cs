using gs_pusher_dotnet.Models;
using PusherServer;
using System.Configuration;
using System.Web.Mvc;

namespace gs_pusher_dotnet.Controllers
{
    public class PrivateController : Controller
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

            IAuthenticationData authData = pusher.Authenticate(model.channel_name, model.socket_id);
            return Json(authData);
        }
    }
}