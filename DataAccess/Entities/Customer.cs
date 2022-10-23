using AppCore.Records.Bases;
using DataAccess.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public partial class Customer : RecordBase
    {
        [Required(ErrorMessage = "{0} is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Gender? Gender { get; set; }
        public CustomerDetails? CustomerDetails { get; set; }
        public List<CustomerHotel>? CustomerHotels { get; set; }
        public List<CustomerRoom>? CustomerRoom { get; set; }

    }

    public partial class Customer
    {
        [NotMapped]
        [DisplayName("Name")]
        public string? NameDisplay { get; set; }

        [NotMapped]
        [DisplayName("Last Name")]
        public string? LastNameDisplay { get; set; }

        [NotMapped]
        [DisplayName("Date Of Birth")]
        public string? DateOfBirthDisplay { get; set; }

        [NotMapped]
        [DisplayName("Gender")]
        public Gender? GenderDisplay { get; set; }

    }
}
