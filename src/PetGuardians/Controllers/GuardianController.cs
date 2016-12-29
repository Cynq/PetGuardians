using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGuardians.Data;
using PetGuardians.Entities;
using PetGuardians.Models;
using PetGuardians.Models.AccountViewModels;
using PetGuardians.Models.Guardian;


namespace PetGuardians.Controllers
{
    public class GuardianController : Controller
    {
        private ApplicationDbContext _context;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public GuardianController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("opieka/szukaj")]
        public IActionResult Index()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == UserId);

            var offers = _context.Offers
                .Include(x => x.Offers)
                .Select(x => new OfferVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    From = x.From,
                    To = x.To,
                    Price = x.Price,
                    Added = x.Added,
                    Town = x.Town,
                    MyOffer = UserId == x.Owner.Id,
                    CanApply = !x.Offers.Select(u => u.Id).Contains(UserId) && user.Type == UserType.Guardian
                }).ToList();

            return View(offers);
        }

        [Route("opieka/zaoferuj")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("opieka/zaoferuj")]
        [HttpPost]
        public IActionResult Create(OfferVm model)
        {
            if (ModelState.IsValid)
            {
                var usr = _context.Users.FirstOrDefault(x => x.Id == UserId);
                var offer = new Offer
                {
                    Name = model.Name,
                    Description = model.Description,
                    From = model.From,
                    To = model.To,
                    Price = model.Price,
                    Town = model.Town,
                    Owner = usr
                };
                _context.Offers.Add(offer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Route("opieka/aplikuj/{id}")]
        public IActionResult Apply(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == UserId);
            var offer = _context.Offers.Include(x => x.Offers).FirstOrDefault(x => x.Id == id);
            offer.Offers.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Route("opieka/moje")]
        public IActionResult MyOffers()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == UserId);
            List<Offer> offers;

            offers = user.Type == UserType.Owner 
                ? _context.Offers.Where(x => x.Owner.Id == UserId).ToList() 
                : _context.Offers.Where(x => x.Offers.Select(y => y.Id).Contains(UserId)).ToList();

            var model = new MyOffersVm
            {
                Offers = offers,
                UserType = user.Type
            };

            return View(model);
        }

        [Route("opieka/{id}")]
        public IActionResult My(int id)
        {
            var offer = _context.Offers
                .Include(x => x.Owner)
                .Include(x => x.Offers)
                .FirstOrDefault(x => x.Id == id);
            if (offer.Owner.Id == UserId)
            {
                return View(offer);
            }
            return RedirectToAction("Index");
        }

        [Route("opieka/edytuj/{id}")]
        public IActionResult Edit(int id)
        {
            var offer = _context.Offers.Include(x => x.Owner).FirstOrDefault(x => x.Id == id);
            if (offer.Owner.Id == UserId)
            {
                return View(offer);
            }
            return RedirectToAction("Index");
        }

        [Route("opieka/edytuj/{id}")]
        [HttpPost]
        public IActionResult Edit(Offer model)
        {
            if (model.Owner.Id == UserId)
            {
                
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Aprove()
        {
            throw new System.NotImplementedException();
        }
    }
}