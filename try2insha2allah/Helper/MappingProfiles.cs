using AutoMapper;
using likeBooking.Models;
using try2insha2allah.DTO;

namespace try2insha2allah.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() { 
            CreateMap<Room,RoomDTO>();
        
        }
    }
}
