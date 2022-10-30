using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class User : RecordBase
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string? Password { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [Required]
        public UserDetails? UserDetails { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role? Role { get; set; }

    }
}
