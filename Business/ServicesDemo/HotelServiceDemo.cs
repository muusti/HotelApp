using Business.Models;
using Business.ServicesDemo.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.ServicesDemo
{
    public class HotelServiceDemo : HotelServiceBaseDemo
    {
        public HotelServiceDemo(Db db) : base(db)
        {
        }
        //public override IQueryable<HotelModel> Query(Hotel hotel)
        //{
        //    return base.Query().Select(h => new HotelModel()
        //    {
        //        Id = hotel.Id,
        //        ModelName = hotel.Name,
        //        ModelCityId = hotel.CityId,
        //        ModelCountryId = hotel.CountryId,
        //        ModelStar = hotel.Star,
        //    });
        //}

        //public override List<HotelModel> GetList()
        //{

        //    return base.GetList();
        //}


    }
}
