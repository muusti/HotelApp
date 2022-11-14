using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ReportModel
    {

        [DisplayName("Customer Full Name")]
        public string? CustomerFullName { get; set; }

        [DisplayName("Hotel Check-In Date")]
        public string? DateOfEntryDisplay { get; set; }

        [DisplayName("Hotel Check-Out Date")]
        public string? ReleaseDateDisplay { get; set; }

        [DisplayName("Hotel Name")]
        public string? HotelName { get; set; }
        public string? Star { get; set; }

        [DisplayName("Room No")]
        public string? RoomNo { get; set; }

        [DisplayName("Room Count")]
        public string? RoomCount { get; set; }

        public int? CustomerId { get; set; }
        public int? RoomId { get; set; }
        public int? HotelId { get; set; }

        [DisplayName("Hotel Check-In Date")]
        public DateTime? DateOfEntry { get; set; }

        [DisplayName("Hotel Check-Out Date")]
        public DateTime? ReleaseDate { get; set; }
    }
}
