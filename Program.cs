
using Hotel_Room_Booking_API.Database;
using Hotel_Room_Booking_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Room_Booking_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>options.UseInMemoryDatabase("HotelDb"));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // seed initial data
                if (!db.Rooms.Any())
                {
                    db.Rooms.AddRange(
                        new Room { Id = 1, Name = "101", Type = "Single", IsAvailable = true },
                        new Room { Id = 2, Name = "102", Type = "Single", IsAvailable = true },
                        new Room { Id = 3, Name = "201", Type = "Double", IsAvailable = true },
                        new Room { Id = 4, Name = "301", Type = "Suite", IsAvailable = true }
                    );
                    db.SaveChanges();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
