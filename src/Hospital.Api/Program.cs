using Hospital.Api.Dal;
using Hospital.Api.Features.Patients.AssignBed;
using Hospital.Api.Features.Patients.GetAll;
using Hospital.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<HospitalDbContext>();
builder.Services.AddScoped<IGetPatientsService, GetPatientsService>();
builder.Services.AddScoped<IAssignBedService, AssignBedService>();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ApplicationExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
