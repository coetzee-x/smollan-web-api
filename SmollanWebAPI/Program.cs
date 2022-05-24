using SmollanWebAPI.Context;
using SmollanWebAPI.Middleware;
using SmollanWebAPI.Services.EncryptService;
using SmollanWebAPI.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IEncryptService), typeof(EncryptService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseMiddleware<AuthorizeMiddleware>();

app.MapControllers();

app.Run();
