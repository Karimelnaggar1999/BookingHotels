using AutoMapper;
using likeBooking.Data;
using likeBooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using try2insha2allah.DTO;
using try2insha2allah.Interfaces;
using try2insha2allah.Repository;

namespace try2insha2allah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomsController(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Room>))]
        public IActionResult GetRooms()
        {

            var rooms = _mapper.Map<List<RoomDTO>>(_roomRepository.GetRooms());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(rooms);
        }
       /* [HttpGet("{Id}")]
        [ProducesResponseType(200, Type=typeof(Room))]
        [ProducesResponseType(400)]
        public IActionResult GetRoom(int id)
        {
            var room = _roomRepository.GetRoom(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(room);

        }*/
        [HttpGet("{priceFrom},{priceTo}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Room>))]
        [ProducesResponseType(400)]
        public IActionResult GetRoomPrice(int priceFrom,int priceTo)
        {
            var rooms = _mapper.Map<List<RoomDTO>>(_roomRepository.GetRoomPrice(priceFrom,priceTo));
           // var rooms = _roomRepository.GetRoomPrice(priceFrom,priceTo);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(rooms);
        }


    }
}
