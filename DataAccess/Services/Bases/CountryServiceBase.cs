using AppCore.DataAccsess.Services;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Services.Bases
{
    public abstract class CountryServiceBase : ServiceBase<Country>
    {
        public CountryServiceBase(Db db) : base(db)
        {
        }
    }
}
