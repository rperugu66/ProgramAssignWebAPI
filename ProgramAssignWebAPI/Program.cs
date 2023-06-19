using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Controllers;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Repositories;
using ProgramAssignWebAPI.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFileService, FileService>();
// to Connect with Db
builder.Services.AddDbContext<AssignDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssignPath"));

});

// Register interface and Repo Class to resolve dependencies
builder.Services.AddScoped<IResourceManagerAssignmentRepo, ResourceManagerAssignmentRepo>();
builder.Services.AddScoped<IProgramTrackerRepo, ProgramTrackerRepo>();
builder.Services.AddScoped<ITechTracks, TechTracksRepo>();
builder.Services.AddScoped<IUserInfoRepo, UserInfoRepo>();
builder.Services.AddDbContext<LoginInfoDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AssignPath")));
//builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();


// to inject automapper profiles
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
      .AllowAnyHeader());
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
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();
