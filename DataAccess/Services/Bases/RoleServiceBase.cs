using AppCore.DataAccsess.Services;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Services.Bases
{
    public abstract class RoleServiceBase : ServiceBase<Role>
    {
        public RoleServiceBase(Db db) : base(db)
        {

        }
    }
}
