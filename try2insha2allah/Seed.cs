using likeBooking.Data;
using likeBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace likeBooking
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            //using (var context = new DataContext())
            //{
                // Creates the database if not exists
                dataContext.Database.EnsureCreated();

                // Adds a publisher
                var sheraton = new Hotel
                {
                    Name = "Sheraton Hotel",
                    Id=1
                };
                dataContext.Hotels.Add(sheraton);
                var helnan = new Hotel
                {
                    Name = "Helnan Hotel",
                    Id=2
                };
                dataContext.Hotels.Add(helnan);
                var tolip = new Hotel
                {
                    Name = "Tolip Hotel",
                    Id=3
                };
                dataContext.Hotels.Add(tolip);

                // Adds some books
                dataContext.Rooms.Add(new Room
                {
                    Id = 1,
                    Description = "Double Room Sea View",
                    Price = 200,
                    Hotel = sheraton,
                    HotelId=1,
                    HotelName = "Sheraton Hotel",
                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 2,
                    Description = "Single Room Sea View",
                    Price = 150,
                    Hotel = sheraton,
                    HotelId = 1,
                    HotelName = "Sheraton Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 3,
                    Description = "Double Room City View",
                    Price = 170,
                    Hotel = sheraton,
                    HotelId = 1,
                    HotelName = "Sheraton Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 4,
                    Description = "Single Room City View",
                    Price = 120,
                    Hotel = sheraton,
                    HotelId = 1,
                    HotelName = "Sheraton Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 5,
                    Description = "Double Room Garden View",
                    Price = 100,
                    Hotel = helnan,
                    HotelId = 2,
                    HotelName = "Helnan Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 6,
                    Description = "Single Room Garden View",
                    Price = 90,
                    Hotel = helnan,
                    HotelId = 2,
                    HotelName = "Helnan Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 7,
                    Description = "Double Room Pool View",
                    Price = 120,
                    Hotel = helnan,
                    HotelId = 2,
                    HotelName = "Helnan Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 8,
                    Description = "Single Room Pool View",
                    Price = 110,
                    Hotel = helnan,
                    HotelId = 2,
                    HotelName = "Helnan Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 9,
                    Description = "Double Room Standard",
                    Price = 80,
                    Hotel = tolip,
                    HotelId = 3,
                    HotelName = "Tolip Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 10,
                    Description = "Single Room Standard",
                    Price = 70,
                    Hotel = tolip,
                    HotelId = 3,
                    HotelName = "Tolip Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 11,
                    Description = "Double Room Deluxe",
                    Price = 100,
                    Hotel = tolip,
                    HotelId = 3,
                    HotelName = "Tolip Hotel",

                });
                dataContext.Rooms.Add(new Room
                {
                    Id = 12,
                    Description = "Single Room Standard",
                    Price = 95,
                    Hotel = tolip,
                    HotelId = 3,
                    HotelName = "Tolip Hotel",

                });



                // Saves changes
                dataContext.SaveChanges();
            //}
        }
    }
            

}


