using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGuardians.Data;
using PetGuardians.Entities;
using PetGuardians.Models.Guardian;
using Microsoft.AspNetCore.Authorization;

namespace PetGuardians.Controllers
{
    [Authorize]
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
            var offers = _context.Offers
                .Include(x => x.Owner)
                .Include(x => x.Offers).ToList();

            var offersVm = offers.Select(x => new OfferVm
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
                CanApply = x.Offers != null && !x.Offers.Select(u => u.Id).Contains(UserId),
                Owner = x.Owner,
                CanRate = CheckIfCanRate(x) 
            }).ToList();

            return View(offersVm);
        }

        private bool CheckIfCanRate(Offer offer)
        {
            if (offer.Owner.Id != UserId || offer.Offers.Any(o => o.Id == UserId))
                return false;

            return offer.Invisible;
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
            var offers = _context.Offers.Where(x => x.Owner.Id == UserId).ToList();

            var model = new MyOffersVm
            {
                Offers = offers
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

        [Route("opieka/zaakceptuj/{id}")]
        public IActionResult Aprove(int id, string userId)
        {
            var offerToAprove = _context.Offers
                .Include(o => o.Owner)
                .FirstOrDefault(o => o.Id == id);

            if (offerToAprove.Owner.Id == UserId)
            {
                var client = _context.Users.FirstOrDefault(u => u.Id == userId);
                var owner = _context.Users.FirstOrDefault(u => u.Id == offerToAprove.Owner.Id);

                var message = new Message
                {
                    SentTime = DateTime.Now,
                    From = owner,
                    To = client,
                    Body =
                        $"{owner.FirstName} {owner.LastName} zaakceptowa³ twoje zg³oszenie opieki dla og³oszenia: {offerToAprove.Name}. Prosimy siê zg³osiæ po szczegó³y na numer {owner.PhoneNumber}"
                };
                offerToAprove.Invisible = true;

                _context.Messages.Add(message);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}