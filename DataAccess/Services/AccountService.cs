using AppCore.DataAccsess.Results.Bases;
using DataAccess.Entities;
using DataAccess.Models;
using DataAccess.Services.Bases;

namespace DataAccess.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserServiceBase _userService;


        public AccountService(UserServiceBase userService)
        {
            _userService = userService;
        }

        public User Login(AccountLoginModel model)
        {
            var user = _userService.Query().SingleOrDefault(u => u.UserName == model.UserName && u.Password == model.Password && u.IsActive);
            return user;
        }

        public Result Register(AccountRegisterModel model)
        {
            var user = new User()
            {
                UserName = model.UserName,
                Password = model.Password,
                UserDetails = new UserDetails()
                {
                    Email = model.Email,
                    Gender = model.Gender,
                    CountryId = model.CountryId,
                    CityId = model.CityId,
                    Address = model.Address
                },
                IsActive = true,
                RoleId = 2
            };

            return _userService.Add(user);
        }
    }
}
