using AppCore.DataAccsess.Results.Bases;
using DataAccess.Entities;
using DataAccess.Models;
using DataAccess.Services.Bases;

namespace DataAccess.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserServiceBase _userService;
        private readonly RoleServiceBase _roleService;


        public AccountService(UserServiceBase userService, RoleServiceBase roleService)
        {
            _userService = userService;
            _roleService = roleService;
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
                RoleId = _roleService.Query().SingleOrDefault(r=> r.Name == "user").Id
            };

            return _userService.Add(user);
        }
    }
}
