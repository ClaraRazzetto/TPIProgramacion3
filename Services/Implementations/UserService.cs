using AutoMapper;
using Shop.API.Data.Interfaces;
using Shop.API.Services.Interfaces;

namespace Shop.API.Services.Implementations
{
    public class UserService : IUserService
    {
        internal readonly IUserRepository _userRepository;
        internal readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
            _userRepository.SaveChanges();
        }

    }
}
