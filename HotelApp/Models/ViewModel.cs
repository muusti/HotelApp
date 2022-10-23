using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelApp.Models
{
    public class ViewModel
    {
        public SelectList Countries { get; set; }
        public SelectList Cities { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
