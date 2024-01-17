using likeBooking.Data;
using likeBooking.Models;
using try2insha2allah.Interfaces;

namespace try2insha2allah.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;
        public RoomRepository(DataContext context) { 
            _context = context;
        }

        /*public Room GetRoom(int roomId)
        {
            return _context.Rooms.Where(p => p.Id == roomId).FirstOrDefault();
        }*/

        public ICollection<Room> GetRoomPrice(int pricefrom,int priceto)
        {
            return _context.Rooms.Where(c => c.Price >= pricefrom & c.Price <= priceto).OrderBy(p => p.Id).ToList();
        }
        
        public ICollection<Room> GetRooms()
        {
            return _context.Rooms.OrderBy(p => p.Id).ToList();
        } 
    }
}
