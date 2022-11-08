using System.ComponentModel;

namespace DataAccess.Models
{
    public class ReportFilterModel
    {
        [DisplayName("Room")]
        public int? RoomId { get; set; }

        [DisplayName("Hotel")]
        public int? HotelId { get; set; }

        [DisplayName("Hotel Name")]
        public string? HotelName { get; set; }

        [DisplayName("Customer")]
        public int? CustomerId { get; set; }
        public List<int>? CustomerIds { get; set; }

        [DisplayName("Date")]
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

    }
}
