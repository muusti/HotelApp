using DataAccess.Entities;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelApp.Models
{
    public class ViewModel
    {
        public SelectList? Countries { get; set; }
        public SelectList? Cities { get; set; }
        public SelectList? Hotels { get; set; }
        public SelectList? Customers { get; set; }
        public SelectList? Rooms { get; set; }
        public List<ReportModel>? ReportModel { get; set; }
        public ReportFilterModel? Filter { get; set; }
    }
}
