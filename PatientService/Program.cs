using Microsoft.EntityFrameworkCore;
using PatientService.Data;
using PatientService.Repositories;
using PatientService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(); 
// Add services to the container.
 //builder.Services.AddDbContext<PatientDbContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("Database") ?? string.Empty));
 builder.Services.AddDbContext<PatientDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Database")));


builder.Services.AddControllers();
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IPatientService, PatientService.Services.PatientService>();

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
