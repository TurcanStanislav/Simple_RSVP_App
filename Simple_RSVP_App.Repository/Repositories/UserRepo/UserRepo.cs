using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Simple_RSVP_App.Domain.Entities;
using Simple_RSVP_App.EntityFramework.DbConnection;
using Simple_RSVP_App.Repository.Interfaces;
using Simple_RSVP_App.Repository.Repositories.UserRepo.DTOs;

namespace Simple_RSVP_App.Repository.Repositories.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateUser(UserDTO user)
        {
            _context.Users.Add(_mapper.Map<User>(user));
            _context.SaveChanges();
        }

        public UserAnalyticsDTO GetAnalytics()
        {
            return new UserAnalyticsDTO
            {
                NumberOfAccepted = _context.Users.Where(u => u.Status == State.Yes).Count(),
                NumberOfDenied = _context.Users.Where(u => u.Status == State.No).Count(),
                NumberOfNotSure = _context.Users.Where(u => u.Status == State.Not_sure).Count(),
            };
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByFilter(State? state)
        {
            if (state == null)
                return _mapper.Map<IEnumerable<UserDTO>>(await _context.Users.ToListAsync());
            else
                return _mapper.Map<IEnumerable<UserDTO>>(await _context.Users.Where(u => u.Status == state).ToListAsync());
        }
    }
}
