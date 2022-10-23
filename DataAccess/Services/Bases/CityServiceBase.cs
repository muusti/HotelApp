using AppCore.DataAccsess.Services;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Services.Bases
{
    public abstract class CityServiceBase : ServiceBase<City>
    {
        public CityServiceBase(Db db) : base(db)
        {

        }
    }
}
