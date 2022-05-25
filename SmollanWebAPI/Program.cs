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

builder.Services.AddMemoryCache();


var app = builder.Build();

app.UseMiddleware<AuthorizeMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
