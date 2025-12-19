using Hotel_Room_Booking_API.Model;

namespace Hotel_Room_Booking_API.Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllRoomsAsync();
    }
}
