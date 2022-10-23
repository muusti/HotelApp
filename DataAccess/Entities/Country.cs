using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Country : RecordBase
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Country Name")]
        [StringLength(150)]
        public string? Name { get; set; }
        public List<City>? Cities { get; set; }
        public List<CustomerDetails>? CustomerDetails { get; set; }
        public List<Hotel>? Hotels { get; set; }
    }
}
