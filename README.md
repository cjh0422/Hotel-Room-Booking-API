# Hotel Room Booking API

A simple API for managing hotel rooms and bookings, built with **ASP.NET Core Web API** and **Entity Framework Core** using an in-memory database.

## Features

- List all rooms (`GET /api/rooms`)
- List all bookings (`GET /api/bookings`)
- Create a new booking (`POST /api/bookings`)
  - Validates that the room exists and is available
  - Automatically sets the room as unavailable after booking
- Swagger UI for interactive API documentation

## How to Run the Application

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (or later)
- better is .NET 10.0 SDK as used in this project

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/Hotel-Room-Booking-API.git
   cd Hotel-Room-Booking-API

2. Restore dependencies:
   ```bash
   dotnet restore
   dotnet run

3. Open your browser and navigate to https://localhost:xxxx/swagger to access the Swagger UI and test the API endpoints.

4. Testing the API:
   - GET /api/rooms → Returns the list of seeded rooms
   - POST /api/bookings,eg:
	 ```json
   {
	"guestName": "John Doe",
    "roomId": 1,
    "checkInDate": "2025-05-01",
    "checkOutDate": "2025-05-03"
   ```




## Design Decisions
1. In-Memory Database: Used Microsoft.EntityFrameworkCore.InMemory as specified in the task. This is ideal for testing and development without requiring a real database setup.
2. Minimal Architecture: Kept the project simple and focused on core requirements. Used controllers directly with DbContext injection for clarity and beginner-friendliness.
3. Manual Availability Check: Implemented basic validation in the booking creation endpoint to prevent booking unavailable rooms.
4. Seeded Data: Added initial rooms in OnModelCreating for immediate testing without manual insertion.
5. Swagger Integration: Enabled OpenAPI/Swagger for easy API exploration and testing.

### Packages Used
1. Microsoft.AspNetCore.OpenApi - OpenAPI/Swagger support
2. Microsoft.EntityFrameworkCore.InMemory – In-memory database
3. Swashbuckle.AspNetCore – Swagger documentation
