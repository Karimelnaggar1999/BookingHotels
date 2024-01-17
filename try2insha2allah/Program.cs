using likeBooking;
using likeBooking.Data;
using likeBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using try2insha2allah.Interfaces;
using try2insha2allah.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("AppDbConnectionString"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("AppDbConnectionString")));
});
var app = builder.Build();
// Startup.cs

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/* class Program
{
    static void Main(string[] args)
    {
        InsertData();
        //PrintData();
    }

    private static void InsertData()
    {
        using (var context = new DataContext())
        {
            // Creates the database if not exists
            context.Database.EnsureCreated();

            // Adds a publisher
            var sheraton = new Hotel
            {
                Name = "Sheraton Hotel"
            };
            context.Hotels.Add(sheraton);
            var helnan = new Hotel
            {
                Name = "Helnan Hotel"
            };
            context.Hotels.Add(helnan);
            var tolip = new Hotel
            {
                Name = "Tolip Hotel"
            };
            context.Hotels.Add(tolip);

            // Adds some books
            context.Rooms.Add(new Room
            {
                Id = 1,
                Description = "Double Room Sea View",
                Price = 200,
                Hotel = sheraton
            });
            context.Rooms.Add(new Room
            {
                Id = 2,
                Description = "Single Room Sea View",
                Price = 150,
                Hotel = sheraton
            });
            context.Rooms.Add(new Room
            {
                Id = 3,
                Description = "Double Room City View",
                Price = 170,
                Hotel = sheraton
            });
            context.Rooms.Add(new Room
            {
                Id = 4,
                Description = "Single Room City View",
                Price = 120,
                Hotel = sheraton
            });
            context.Rooms.Add(new Room
            {
                Id = 5,
                Description = "Double Room Garden View",
                Price = 100,
                Hotel = helnan
            });
            context.Rooms.Add(new Room
            {
                Id = 6,
                Description = "Single Room Garden View",
                Price = 90,
                Hotel = helnan
            });
            context.Rooms.Add(new Room
            {
                Id = 7,
                Description = "Double Room Pool View",
                Price = 120,
                Hotel = helnan
            });
            context.Rooms.Add(new Room
            {
                Id = 8,
                Description = "Single Room Pool View",
                Price = 110,
                Hotel = helnan
            });
            context.Rooms.Add(new Room
            {
                Id = 9,
                Description = "Double Room Standard",
                Price = 80,
                Hotel = tolip
            });
            context.Rooms.Add(new Room
            {
                Id = 10,
                Description = "Single Room Standard",
                Price = 70,
                Hotel = tolip
            });
            context.Rooms.Add(new Room
            {
                Id = 11,
                Description = "Double Room Deluxe",
                Price = 100,
                Hotel = tolip
            });
            context.Rooms.Add(new Room
            {
                Id = 12,
                Description = "Single Room Standard",
                Price = 95,
                Hotel = tolip
            });



            // Saves changes
            context.SaveChanges();
        }
    }

   /* private static void PrintData()
    {
        // Gets and prints all books in database
        using (var context = new LibraryContext())
        {
            var books = context.Book
              .Include(p => p.Publisher);
            foreach (var book in books)
            {
                var data = new StringBuilder();
                data.AppendLine($"ISBN: {book.ISBN}");
                data.AppendLine($"Title: {book.Title}");
                data.AppendLine($"Publisher: {book.Publisher.Name}");
                Console.WriteLine(data.ToString());
            }
        }
    }*/
//}


