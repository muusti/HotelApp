using AppCore.DataAccsess.Services;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services.Bases
{
    public class RoomServiceBase : ServiceBase<Room>
    {
        public RoomServiceBase(Db db) : base(db)
        {
        }
    }
}
