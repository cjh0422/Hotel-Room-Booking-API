using Hotel_Room_Booking_API.DTO;
using Hotel_Room_Booking_API.Model;

namespace Hotel_Room_Booking_API.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking> CreateBookingAsync(CreateBookingDto dto);
    }
}
