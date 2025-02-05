using Microsoft.EntityFrameworkCore;
using MyShoppingRepository.Data;
using MyShoppingRepository.Repositories;
using MyShoppingService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("*")  //we can give "*" for any client url
                   .AllowAnyMethod()    //Allolwing all http-get,post,delete etc..
                   .AllowAnyHeader();
        });
});

// Add services to the container.
//Configure - appsetting.json
var sqlconnectionstring = builder.Configuration.GetConnectionString("sqlconn");
builder.Services.AddDbContext<MyshoppingDbContext>(options => options.UseSqlServer(sqlconnectionstring));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
