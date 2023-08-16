using AutoMapper;
using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.Mapping;
using InventoryAppEFCore.Services;
using InventoryAppEFCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<ProductProfile>();
});

builder.Services.AddDbContext<InventoryAppEfCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<InventoryAppEFCoreContextInitializer, InventoryAppEFCoreContextInitializer>();

builder.Services.AddScoped<IInventoryAppService, InventoryAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContextInitialiser = services.GetRequiredService<InventoryAppEFCoreContextInitializer>();

        await dbContextInitialiser.InitialiseAsync();
        dbContextInitialiser.InitializeUDF();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
