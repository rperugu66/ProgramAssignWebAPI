using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// to Connect with Db
builder.Services.AddDbContext<AssignDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssignPath"));
});
// Register interface and Repo Class to resolve dependencies
builder.Services.AddScoped<IResourceManagerAssignmentRepo, ResourceManagerAssignmentRepo>();
builder.Services.AddScoped<IProgramTrackerRepo, ProgramTrackerRepo>();


// to inject automapper profiles
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
