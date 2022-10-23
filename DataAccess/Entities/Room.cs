using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public partial class Room : RecordBase
    {
        [Required(ErrorMessage = "{0} is required")]
        [Range(100, 2000, ErrorMessage = "{0} must be between {1} and {2}")]
        [DisplayName("Room No")]
        public int? RoomNo { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Room Condition")]
        public bool IsEmpty { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Daily Price ")]
        public double? DailyPrice { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int? HotelId { get; set; }

        public Hotel? Hotel { get; set; }
        public RoomFeatures? RoomFeatures { get; set; }
        public List<CustomerRoom>? CustomerRoom { get; set; }

    }

    public partial class Room
    {
        [NotMapped]
        [DisplayName("Room Condition")]
        public string? IsEmptyDisplay { get; set; }

        [NotMapped]
        [DisplayName("Daily Price ")]
        public string? DailyPriceDisplay { get; set; }

        [NotMapped]
        [DisplayName("Weekly Price ")]
        public string? WeeklyPriceDisplay { get; set; }

    }
}
