using DataAccess.Contexts;
using DataAccess.Services.Bases;

namespace DataAccess.Services
{
    public class RoleService : RoleServiceBase
    {
        public RoleService(Db db) : base(db)
        {
        }
    }
}
