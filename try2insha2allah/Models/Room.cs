﻿namespace likeBooking.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public  Hotel Hotel { get; set; }
    }
}
