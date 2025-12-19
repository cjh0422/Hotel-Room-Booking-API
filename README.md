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
