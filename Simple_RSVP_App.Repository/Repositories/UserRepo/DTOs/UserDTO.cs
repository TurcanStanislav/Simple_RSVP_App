using Simple_RSVP_App.Domain.Entities;

namespace Simple_RSVP_App.Repository.Repositories.UserRepo.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public State Status { get; set; }
    }
}
