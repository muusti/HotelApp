using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class RoomFeatures
    {
        [Key]
        public int? RoomId { get; set; }

        public Room? Room { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(1, 4, ErrorMessage = "{0} must be between {1} and {2}")]
        [DisplayName("Room Type")]
        public RoomType? RoomType { get; set; }

        [DisplayName("Room m2")]
        public double? m2 { get; set; }

    }
}
