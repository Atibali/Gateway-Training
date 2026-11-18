using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;

var builder=WebApplication.CreateBuilder(args);

//Register Controller
builder.Services.AddControllers();
builder.Services.AddCors();

// Register Sql server Db
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app=builder.Build();

// Allow only the local Angular dev server during development.
if (app.Environment.IsDevelopment())
{
    app.UseCors(policy => policy
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());
}

// Swagger
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();