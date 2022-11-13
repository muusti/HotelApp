using AppCore.Records.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccess.Entities
{
    public class Hotel : RecordBase
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50)]
        [DisplayName("Hotel Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(0, 7, ErrorMessage = "{0} must be between {1} and {2}")]
        public int? Star { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Country")]
        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public List<Room>? Rooms { get; set; }


        [JsonIgnore]
        [Column(TypeName = "image")]
        public byte[]? Image { get; set; }

        [JsonIgnore]
        [StringLength(5)]
        public string? ImageExtension { get; set; }



        [NotMapped]
        [DisplayName("Image")]
        public string? ImageTagSrcDisplay { get; set; }

    }
}
