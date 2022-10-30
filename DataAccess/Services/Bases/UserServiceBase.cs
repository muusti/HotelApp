using AppCore.DataAccsess.Services;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services.Bases
{
    public class UserServiceBase : ServiceBase<User>
    {
        public UserServiceBase(Db db) : base(db)
        {

        }
    }
}
