using Employee_Api_23_12.Data;
using Employee_Api_23_12.Models;
using Employee_Api_23_12.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer("EmployeeConnetion"));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnetion")));

builder.Services.AddScoped<Employee>();
builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")  // Your Angular app's URL
               .AllowAnyMethod()
               .AllowAnyHeader();
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

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAngularApp");
//app.UseCors(option=> option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();
