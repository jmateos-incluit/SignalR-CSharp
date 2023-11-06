using WebApplication1.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
////////////////////////////////////////////////////////
builder.Services.AddSignalR(); ////////////////////////////
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:5173")
            .AllowCredentials();
    });
});
////////////////////////////////////////////////////////
var app = builder.Build();


app.UseAuthorization();

app.UseCors("ClientPermission");
app.MapControllers();

///////////////////////////////////////////////////

    app.MapHub<MessageHub>("/mesage");

///////////////////////////////////////////////////


app.Run();
