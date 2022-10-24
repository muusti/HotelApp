using AppCore.Records.Bases;
using DataAccess.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class CityModel : RecordBase
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("City Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Country")]
        public int? CountryId { get; set; }

        public CountryModel? Country { get; set; }

        public List<HotelModel>? Hotels { get; set; }
    }
}
