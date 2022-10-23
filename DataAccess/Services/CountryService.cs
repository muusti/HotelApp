using DataAccess.Contexts;
using DataAccess.Services.Bases;

namespace DataAccess.Services
{
    public class CountryService : CountryServiceBase
    {
        public CountryService(Db db) : base(db)
        {
        }
    }
}
