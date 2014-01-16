using MvcMovie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IMessageService _messageService;
        public HelloWorldController(IMessageService  messageService)
        {
            _messageService = messageService;
        }
 
        public ActionResult Index()
        {
            ViewBag.Message = _messageService.GetWelcomeMessage();
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
	}
}