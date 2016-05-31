using gs_pusher_dotnet.Models;
using PusherServer;
using System.Configuration;
using System.Net;
using System.Web.Mvc;

namespace gs_pusher_dotnet.Controllers
{
    public class TriggerController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.PusherAppKey = ConfigurationManager.AppSettings["PusherAppKey"];
            return View();
        }

        [HttpPost]
        public ActionResult Index(TriggerModel model)
        {
            var pusher = new Pusher(
                ConfigurationManager.AppSettings["PusherAppId"],
                ConfigurationManager.AppSettings["PusherAppKey"],
                ConfigurationManager.AppSettings["PusherAppSecret"]);

            // TODO: implement checks to determine if the user is:
            // 1. Authenticated with the app
            // 2. Allowed to trigger on the channel
            // 3. Sanitize any additional data that has been recieved and is to be used
            // If so, proceed...

            pusher.Trigger("my-channel", "my-event", new { message = model.Message });
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}