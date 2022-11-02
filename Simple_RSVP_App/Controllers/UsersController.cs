using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_RSVP_App.EntityFramework.DbConnection;
using Simple_RSVP_App.Domain.Entities;
using Simple_RSVP_App.ViewModels;
using Simple_RSVP_App.Repository.Interfaces;
using MapsterMapper;
using Simple_RSVP_App.Repository.Repositories.UserRepo.DTOs;

namespace Simple_RSVP_App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetForm()
        {
            return View("Form");
        }

        public IActionResult Create(UserDTO user)
        {
            _userRepo.CreateUser(user);

            return RedirectToAction(nameof(GetForm));
        }

        public async Task<IActionResult> GetAnalytics()
        {
            var vm = _mapper.Map<UsersViewModel>(_userRepo.GetAnalytics());
            return View("UsersAnalytics", vm);
        }

        public async Task<IActionResult> GetUsersByFilter(State? state)
        {
            var vm = new UsersViewModel { Users = await _userRepo.GetUsersByFilter(state) };
            return PartialView("_UsersTablePartialView", vm);
        }
    }
}
