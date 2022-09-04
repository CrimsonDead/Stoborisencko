using datalayer.Context;
using datalayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using datalayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = builder.Environment.IsDevelopment() ? 
    builder.Configuration.GetConnectionString("DevelopmentConnection") :
    builder.Configuration.GetConnectionString("ReleaseConnection");
builder.Services.AddDbContext<ApplicationContext>(builder =>{
    builder.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<User, IdentityRole>(o =>{
    o.Password.RequireNonAlphanumeric = true;
    o.Password.RequireDigit = true;
})
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IRepository<Car>, CarRepository>();
builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
builder.Services.AddScoped<IRepository<Offer>, OfferRepository>();
builder.Services.AddScoped<IRepository<Service>, ServiceRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
