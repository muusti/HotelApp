using DataAccess.Contexts;
using DataAccess.Services.Bases;

namespace DataAccess.Services
{
    public class CityService : CityServiceBase
    {
        public CityService(Db db) : base(db)
        {

        }
    }
}
