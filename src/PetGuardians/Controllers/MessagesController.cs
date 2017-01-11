using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGuardians.Data;
using PetGuardians.Entities;
using System;
using PetGuardians.Models;

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
                .Where(msg => msg.To.Id == UserId)
                .OrderByDescending(m => m.SentTime)
                .ToList();

            var model = new MessagesIndexVm
            {
                Messages = messages,
                UserId = UserId
            };

            return View(model);
        }

        [Route("wiadomosci/nowa/{id}")]
        public IActionResult Create(string id)
        {
            var reciver = _context.Users.FirstOrDefault(u => u.Id == id);
            var model = new Message
            {
                To = reciver
            };

            return View(model);
        }
        
        [HttpPost]
        [Route("wiadomosci/nowa/{id}")]
        public IActionResult Create(Message model)
        {
            model.To = _context.Users.FirstOrDefault(u => u.Id == model.To.Id);
            model.From = _context.Users.FirstOrDefault(u => u.Id == UserId);
            model.SentTime = DateTime.Now;

            var rates = _context.Rates.ToList();


            _context.Entry(model).State = EntityState.Added;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}