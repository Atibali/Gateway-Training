using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;

var builder=WebApplication.CreateBuilder(args);

//Register Controller
builder.Services.AddControllers();

// Register Sql server Db
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app=builder.Build();

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