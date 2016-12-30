using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGuardians.Data;

namespace PetGuardians.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext _context;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("wiadomosci")]
        public IActionResult Index()
        {
            var messages = _context.Messages
                .Include(msg => msg.From)
                .Include(msg => msg.To)
                .Where(msg => msg.From.Id == UserId)
                .ToList();

            return View(messages);
        }

        [Route("wiadomosci/nowa/{id}")]
        public IActionResult Create(string id)
        {
            return View(id);
        }
    }
}