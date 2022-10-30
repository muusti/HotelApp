﻿using DataAccess.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class AccountRegisterModel
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

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        [StringLength(250)]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string? Email { get; set; }

        [Required]
        [DisplayName("Country")]
        public int? CountryId { get; set; }

        [Required]
        [DisplayName("City")]
        public int? CityId { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Address { get; set; }
    }
}
