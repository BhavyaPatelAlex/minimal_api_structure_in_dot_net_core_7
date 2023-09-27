using InfucareRx.PatientHealthApp.Database;
using Microsoft.EntityFrameworkCore;
using InfucareRx.PatientHealthApp.Repository;
using InfucareRx.PatientHealthApp.Serivces;
using InfucareRx.PatientHealthApp.Middlewares;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddServices();
//builder.Services.AddLogging(logging => logging.AddConsole());

builder.Services.AddDbContext<InfucareRxPatientHealthAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InfucareRxDb"));
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API");

    });
    app.UseMiddleware<ExceptionMiddleware>();
}
else
{
    app.UseMiddleware<ExceptionMiddleware>();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


