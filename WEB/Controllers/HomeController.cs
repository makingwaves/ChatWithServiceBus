using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ServiceBus.Messaging;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult SendMessage(string message)
        {
            var client = QueueClient.CreateFromConnectionString("Endpoint=sb://servicebuschat.servicebus.windows.net/;SharedAccessKeyName=myqueuesharedpolicy;SharedAccessKey=2MmMOy8HxvJ16qhofdVxIRc/AAFK1aKaojvwuxRDOPk=;EntityPath=myqueue");

            client.Send(new BrokeredMessage(message));

            return View("Index");
        }
    }
}