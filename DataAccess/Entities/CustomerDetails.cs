using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public partial class CustomerDetails
    {
        [Required(ErrorMessage = "{0} is required")]
        [Key]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
       

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(250)]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Phone]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Identification Number")]
        public string? IdentificationNo { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Country")]
        public int? CountryId { get; set; }
        public Country? Country { get; set; }

    }

    public partial class CustomerDetails
    {

        [StringLength(250)]
        [EmailAddress]
        [DisplayName("E-Mail")]
        [NotMapped]
        public string? EmailDisplay { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        [NotMapped]
        public string? PhoneNumberDisplay { get; set; }

        [DisplayName("Identification Number")]
        [NotMapped]
        public string? IdentificationNoDisplay { get; set; }

        [DisplayName("Adrress")]
        [NotMapped]
        public string? AddressDisplay { get; set; }
    }
}
