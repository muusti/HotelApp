namespace DataAccess.Models
{
    public class FavoriteItemGroupByModel
    {
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }


        public int Star { get; set; }
        public int HotelCount { get; set; }
    }
}
