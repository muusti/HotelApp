using AppCore.Records.Bases;
using DataAccess.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class HotelModel : RecordBase
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50)]
        [DisplayName("Hotel Name")]
        public string? ModelName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(0, 7, ErrorMessage = "{0} must be between {1} and {2}")]
        public int? ModelStar { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("City")]
        public int? ModelCityId { get; set; }
        public CityModel? ModelCity { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Country")]
        public int? ModelCountryId { get; set; }
        public CountryModel? ModelCountry { get; set; }

        public List<Room>? ModelRooms { get; set; }


    }
}
