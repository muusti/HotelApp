using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class CustomerHotel
    {
        [Key]
        [Column(Order = 0)]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        [DisplayName("Hotel Check-In Date")]
        public DateTime? DateOfEntry { get; set; }

        [DisplayName("Hotel Check-Out Date")]

        public DateTime? ReleaseDate { get; set; }
    }
}
