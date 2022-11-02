using Simple_RSVP_App.Domain.Entities;
using Simple_RSVP_App.Repository.Repositories.UserRepo.DTOs;
using System;

namespace Simple_RSVP_App.Repository.Interfaces
{
    public interface IUserRepo
    {
        void CreateUser(UserDTO user);
        Task<IEnumerable<UserDTO>> GetUsersByFilter(State? state);
        UserAnalyticsDTO GetAnalytics();
    }
}
