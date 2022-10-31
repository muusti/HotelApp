using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class City : RecordBase
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("City Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Country")]
        public int? CountryId { get; set; }

        public Country? Country { get; set; }

        public List<Customer>? Customer { get; set; }
        public List<Hotel>? Hotels { get; set; }
        public List<UserDetails>? UserDetails { get; set; }

    }
}
