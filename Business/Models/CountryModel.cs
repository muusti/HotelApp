using AppCore.Records.Bases;
using DataAccess.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class CountryModel : RecordBase
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Country Name")]
        [StringLength(150)]
        public string? Name { get; set; }
        public List<CityModel>? Cities { get; set; }
        public List<CustomerDetails>? CustomerDetails { get; set; }
        public List<HotelModel>? Hotels { get; set; }
    }
}
