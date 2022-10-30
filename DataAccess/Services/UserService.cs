using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services
{
    public class UserService : UserServiceBase
    {
        public UserService(Db db) : base(db)
        {
        }

        public override IQueryable<User> Query()
        {
            return base.Query().Include(u => u.Role)
                .Include(ud => ud.UserDetails);
        }

        public override Result Add(User entity, bool save = true)
        {
            if (Query().Any(u => u.UserName == entity.UserName))
                return new ErrorResult("User with same name exists");
            if (Query().Any(u => u.UserDetails.Email == entity.UserDetails.Email))
                return new ErrorResult("User with same E-Mail exists");

            return base.Add(entity, save);
        }
    }
}
