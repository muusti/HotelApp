using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using AppCore.DataAccsess.Services;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services.Bases
{
    public abstract class RoomServiceBase : ServiceBase<Room>
    {
        public RoomServiceBase(Db db) : base(db)
        {
        }

        public Result Delete1(Room room)
        {

            _dbContext.Set<RoomFeatures>().RemoveRange(room.RoomFeatures);
            _dbContext.Set<Room>().Remove(room);

            return new SuccessResult();
        }
    }
}
