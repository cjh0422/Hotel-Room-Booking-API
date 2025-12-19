using Hotel_Room_Booking_API.Model;
using Hotel_Room_Booking_API.Repositories;

namespace Hotel_Room_Booking_API.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Room>> GetAllRoomsAsync() => await _repository.GetAllAsync();
    }
}
