using AppCore.DataAccsess.Results.Bases;
using AppCore.DataAccsess.Services;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Services.Bases
{
    public abstract class HotelServiceBase : ServiceBase<Hotel>
    {
        public HotelServiceBase(Db db) : base(db)
        {

        }

    
        public void DeleteImage(int id)
        {
            var hotel = Query().SingleOrDefault(h => h.Id == id);
            hotel.Image = null;
            hotel.ImageExtension = null;
            base.Update(hotel);
        }

    }
}
