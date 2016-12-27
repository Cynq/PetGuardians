using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetGuardians.Data;
using PetGuardians.Entities;
using PetGuardians.Models.Guardian;

namespace PetGuardians.Controllers
{
    public class GuardianController : Controller
    {
        private ApplicationDbContext _context;

        public GuardianController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("opieka/szukaj")]
        public IActionResult Index()
        {
            var offers = _context.Offers.Select(x => new OfferVm
            {
                Name = x.Name,
                Description = x.Description,
                From = x.From,
                To = x.To,
                Price = x.Price,
                Added = x.Added,
                Town = x.Town
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
                var offer = new Offer
                {
                    Name = model.Name,
                    Description = model.Description,
                    From = model.From,
                    To = model.To,
                    Price = model.Price,
                    Town = model.Town
                };
                _context.Offers.Add(offer);
                _context.SaveChanges();
            }
            return View("Index");
        }
    }
}