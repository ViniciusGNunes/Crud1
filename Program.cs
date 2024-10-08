using Crud1.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
app.MapControllers();


app.MapGet("/", () => "Hello World!");

app.Run();
