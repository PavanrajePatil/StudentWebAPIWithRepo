using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Context;
using StudentWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

string ConnectionString = builder.Configuration.GetConnectionString("StudentDBCon");
builder.Services.AddDbContext<StudentDbContext>(options=>options.UseSqlServer(ConnectionString));
// Add services to the container.

builder.Services.AddScoped<IStudentServices, StudentServices>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
