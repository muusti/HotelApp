using AppCore.DataAccsess.Services;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.ServicesDemo.Bases
{
    public class HotelServiceBaseDemo : ServiceBase<HotelModel>
    {
        public HotelServiceBaseDemo(Db db) : base(db)
        {

        }

       
    }
}
