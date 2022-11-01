using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_RSVP_App.DbConnection;
using Simple_RSVP_App.Entities;
using Simple_RSVP_App.ViewModels;

namespace Simple_RSVP_App.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetForm()
        {
            return View("Form");
        }

        public IActionResult Create(User model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(GetForm));
        }

        public async Task<IActionResult> GetAnalytics()
        {
            var users = await _context.Users.ToListAsync();

            var vm = new UsersViewModel { 
                NumberOfAccepted = _context.Users.Where(u => u.Status == State.Yes).Count(),
                NumberOfDenied = _context.Users.Where(u => u.Status == State.No).Count(),
                NumberOfNotSure = _context.Users.Where(u => u.Status == State.Not_sure).Count(),
            };
            return View("UsersAnalytics", vm);
        }

        public async Task<IActionResult> GetUsersByFilter(State? state)
        {
            IEnumerable<User> users;
            if (state == null)
                users = await _context.Users.ToListAsync();
            else
                users = await _context.Users.Where(u => u.Status == state).ToListAsync();

            var vm = new UsersViewModel { Users = users };
            return PartialView("_UsersTablePartialView", vm);
        }
    }
}
