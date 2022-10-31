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
        public string? GenderDisplay { get; set; }

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

        [DisplayName("Room No")]
        [NotMapped]
        public string? CustomerRoomRoomNoDisplay { get; set; }

        [DisplayName("Hotel Name")]
        [NotMapped]
        public string? CustomerRoomHotelNameDisplay { get; set; }


        [NotMapped]
        [DisplayName("Room")]
        [Required]
        public List<int>? RoomIds { get; set; }

        [NotMapped]
        [DisplayName("Hotel")]
        [Required]
        public List<int>? HotelIds { get; set; }


        [NotMapped]
        [DisplayName("Hotel Check-In Date")]
        public string? DateOfEntryDisplay { get; set; }

        [NotMapped]
        [DisplayName("Hotel Check-Out Date")]
        public string? ReleaseDateDisplay { get; set; }

        [DisplayName("Name And Surname")]
        [NotMapped]
        public string? NameAndSurName { get; set; }


        [NotMapped]
        [Required]
        [DisplayName("Hotel Check-In Date")]
        public DateTime? DateOfEntryDisplay2 { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("Hotel Check-Out Date")]
        public DateTime? ReleaseDateDisplay2 { get; set; }

    }
}
