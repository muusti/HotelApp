using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
                .Include(u => u.UserDetails)
                .Include(u => u.UserDetails.Country)
                .Include(u => u.UserDetails.City)
                .OrderBy(u => u.Role.Name);
        }

        public override Result Add(User entity, bool save = true)
        {
            if (Query().Any(u => u.UserName == entity.UserName))
                return new ErrorResult("User with same name exists");
            if (Query().Any(u => u.UserDetails.Email == entity.UserDetails.Email))
                return new ErrorResult("User with same E-Mail exists");

            return base.Add(entity, save);
        }

        public override Result Update(User entity, bool save = true)
        {
            if (Query().Any(u => u.UserName == entity.UserName && u.Id != entity.Id))
                return new ErrorResult("The user name you entered exists");

            entity.UserName = entity.UserName.Trim();
            entity.UserDetails = new UserDetails()
            {
                UserId = entity.Id,
                Email = entity.UserDetails.Email,
                Gender = entity.UserDetails.Gender,
                Address = entity.UserDetails.Address.Trim(),
                CountryId = entity.UserDetails.CountryId,
                CityId = entity.UserDetails.CityId
            };
            return base.Update(entity, save);
        }

        public override Result Delete(Expression<Func<User, bool>> predicate, bool save = true)
        {
            var user = Query().SingleOrDefault(predicate);
            _dbContext.Set<UserDetails>().RemoveRange(user.UserDetails);
            return base.Delete(predicate, save);
        }
    }
}
