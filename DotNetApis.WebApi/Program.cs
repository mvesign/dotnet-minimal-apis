using DotNetApis.Shared.Filters;
using DotNetApis.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Self-owned services
builder.Services.AddSingleton<BookService>();

// Error handling
builder.Services.AddMvc(_ => _.Filters.Add(typeof(ErrorsExceptionFilter)));

// Controller
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
