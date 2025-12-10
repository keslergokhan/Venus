using Venus.Core.Application;
using Venus.Core.Application.Middlewares;
using Venus.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddVenusApplicationServiceRegistration(builder.Configuration);
builder.Services.AddVenusPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddVenusApplicationAuthenticationServiceRegistration(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomResultFilterMiddleware>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition =
        System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS politikasý tanýmlanýyor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // burada URL ekliyorsun
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Cookie / Authorization header kullanacaksan þart
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");
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
