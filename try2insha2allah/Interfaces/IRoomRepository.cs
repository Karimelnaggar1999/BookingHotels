using likeBooking.Models;

namespace try2insha2allah.Interfaces
{
    public interface IRoomRepository
    {
        ICollection<Room> GetRooms();
       // Room GetRoom(int roomId);
        ICollection<Room> GetRoomPrice(int pricefrom, int priceto);
    }
}
