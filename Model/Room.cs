namespace Hotel_Room_Booking_API.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public bool IsAvailable { get; set; } = true;
    }
}
