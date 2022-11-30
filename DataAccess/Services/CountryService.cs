using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;

namespace DataAccess.Services
{
    public class CountryService : CountryServiceBase
    {
        public CountryService(Db db) : base(db)
        {
        }

        public override Result Add(Country entity, bool save = true)
        {
            if (Query().Any(c => c.Name.ToLower() == entity.Name.ToLower().Trim()))
                return new ErrorResult("The name you entered exists");

            return base.Add(entity, save);
        }
    }
}
