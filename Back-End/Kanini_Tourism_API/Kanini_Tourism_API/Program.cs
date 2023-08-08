using Kanini_Tourism_API.Models.Data;
using Kanini_Tourism_API.Repositories;
using Kanini_Tourism_API.Repository.Interfaces;
using Kanini_Tourism_API.Repository.Service;
using Kanini_Tourism_API.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUser,UserService>();
builder.Services.AddScoped<ITravelAgentRepository, TravelAgentRepository>();
builder.Services.AddScoped<ITour, TourService>();
builder.Services.AddScoped<ITourSpotRepository, TourSpotRepository>();
builder.Services.AddScoped<ITourHotelLinkRepository, TourHotelLinkRepository>();
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

builder.Services.AddDbContext<AppDbContext>(optionsAction: options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("CORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
