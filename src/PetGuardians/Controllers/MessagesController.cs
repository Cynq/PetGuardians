using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PetGuardians.Controllers
{
    public class MessagesController : Controller
    {
        [Route("wiadomosci")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            throw new NotImplementedException();
        }
    }
}