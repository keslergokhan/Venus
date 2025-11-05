using Venus.Core.Application;
using Venus.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddVenusApplicationServiceRegistration(builder.Configuration);
builder.Services.AddVenusPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddVenusApplicationAuthenticationServiceRegistration(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
