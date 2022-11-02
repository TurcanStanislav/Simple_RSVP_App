using Simple_RSVP_App.Repository.Repositories.UserRepo.DTOs;

namespace Simple_RSVP_App.ViewModels
{
    public class UsersViewModel
    {
        public int? NumberOfAccepted { get; set; }
        public int? NumberOfDenied { get; set; }
        public int? NumberOfNotSure { get; set; }
        public IEnumerable<UserDTO>? Users { get; set; }
    }
}
