using DataAccess.Contexts;
using DataAccess.Models;
using DataAccess.Services.Bases;

namespace DataAccess.Services
{
    public class ReportService : IReportServiceBase
    {
        private readonly Db _db;

        public ReportService(Db db)
        {
            _db = db;
        }

        public List<ReportModel> GetListJoin(ReportFilterModel filter)
        {
            var query = from r in _db.Rooms
                        join h in _db.Hotels.DefaultIfEmpty()
                        on r.HotelId equals h.Id into hotels
                        from h in hotels.DefaultIfEmpty()
                        join cr in _db.CustomerRooms
                        on r.Id equals cr.RoomId into customerroom
                        from cr in customerroom.DefaultIfEmpty()
                        join c in _db.Customers
                        on cr.CustomerId equals c.Id into customers
                        from c in customers.DefaultIfEmpty()
                        join rf in _db.RoomsFeatures
                        on r.Id equals rf.RoomId into roomfeatures
                        from rf in roomfeatures.DefaultIfEmpty()
                        select new ReportModel()
                        {
                            CustomerFullName = c.Name + "" + c.LastName,
                            HotelName = h.Name,
                            RoomNo = r.RoomNo.ToString(),
                            DateOfEntryDisplay = cr.DateOfEntry.Value.ToString("MM/dd/yyyy"),
                            ReleaseDateDisplay = cr.ReleaseDate.Value.ToString("MM/dd/yyyy"),
                            Star = h.Star.ToString(),
                            DateOfEntry = cr.DateOfEntry,
                            ReleaseDate = cr.ReleaseDate,
                            CustomerId = c.Id,
                            HotelId = h.Id,
                            RoomId = r.Id,
                            RoomCount = h.Rooms.Count().ToString(),

                        };

            query = query.OrderBy(q => q.Star)
                .ThenBy(q => q.HotelName)
                .ThenBy(q => q.RoomNo)
                .ThenBy(q => q.CustomerFullName);
            if (filter != null)
            {
                if (filter.CustomerId.HasValue)
                    query = query.Where(q => q.CustomerId == filter.CustomerId);

                if (filter.HotelId.HasValue)
                    query = query.Where(q => q.HotelId == filter.HotelId);

                if (filter.RoomId.HasValue)
                    query = query.Where(q => q.RoomId == filter.RoomId);

                if (filter.CustomerIds != null && filter.CustomerIds.Count > 0)
                    query = query.Where(q => filter.CustomerIds.Contains(q.CustomerId ?? 0));

                if (filter.DateStart.HasValue)
                    query = query.Where(q => q.DateOfEntry >= filter.DateStart.Value);

                if (filter.DateEnd.HasValue)
                    query = query.Where(q => q.ReleaseDate <= filter.DateEnd.Value);

                if (filter.CustomerId.HasValue)
                    query = query.Where(q => q.CustomerId == filter.CustomerId);

                if (!string.IsNullOrWhiteSpace(filter.HotelName))
                    query = query.Where(q => q.HotelName.ToLower().StartsWith(filter.HotelName.ToLower()));
            }

            return query.ToList();

        }
    }
}
