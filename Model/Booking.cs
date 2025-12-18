namespace Hotel_Room_Booking_API.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public string GuestName { get; set; } = "";
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
