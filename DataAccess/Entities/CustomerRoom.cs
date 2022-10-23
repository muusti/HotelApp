﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class CustomerRoom
    {

        [Key]
        [Column(Order = 0)]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
