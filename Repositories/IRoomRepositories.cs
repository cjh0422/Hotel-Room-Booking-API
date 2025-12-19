using Hotel_Room_Booking_API.Model;

namespace Hotel_Room_Booking_API.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task UpdateAsync(Room room);
    }
}
