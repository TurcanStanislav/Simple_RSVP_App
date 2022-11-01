using Simple_RSVP_App.Entities;

namespace Simple_RSVP_App.ViewModels
{
    public class UsersViewModel
    {
        public int? NumberOfAccepted { get; set; }
        public int? NumberOfDenied { get; set; }
        public int? NumberOfNotSure { get; set; }
        public IEnumerable<User>? Users { get; set; }
    }
}
