namespace Hotel_Room_Booking_API.DTO
{
    public class CreateBookingDto
    {
        public string GuestName { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
