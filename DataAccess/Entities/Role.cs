using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Role : RecordBase
    {
        [Required]
        public string? Name { get; set; }

        public List<User>? Users { get; set; }

    }
}
