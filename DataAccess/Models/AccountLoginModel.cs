﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class AccountLoginModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string? Password { get; set; }
    }
}
