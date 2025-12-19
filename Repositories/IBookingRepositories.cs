using Hotel_Room_Booking_API.Model;

namespace Hotel_Room_Booking_API.Repositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync();
        Task AddAsync(Booking booking);
    }
}
