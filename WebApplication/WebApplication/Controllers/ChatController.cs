using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class ChatController : Controller
    {
        // GET: ChatController
        public ActionResult Index()
        {
            return View();
        }
    }
}
