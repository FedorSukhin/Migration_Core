
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Migration_Core.Models;

// создаем конфигурацию
var configuration = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json")
            .Build();
// берем строку подключения из конфигурации 
var connectionString = configuration["ConnectionString"];

// создаем опции
var options = new DbContextOptionsBuilder()
    .UseSqlServer(connectionString)
    .Options;
// создаем DbContext
using var dbContext = new DbContextApp(options);

// передаем в БД данные
//AddData();
await AddDataString();
async Task AddData()
{
    for (int i = 0; i < 10; i++)
    {
        Dish dish = new Dish
        {
            Name = $"Dish{i}",
            //Price = i * 100,
            Description = $"Country{i}"
        };
        dbContext.Dishes.Add(dish);
    }
    await dbContext.SaveChangesAsync();
}
async Task AddDataString()
{
    for (int i = 0; i < 10; i++)
    {
        Dish dish = new Dish
        {
            Name = $"Dish{i}",
            Price = ((i + 10) * 100).ToString(),
            Description = $"Country{i}"
        };
        dbContext.Dishes.Add(dish);
    }
    await dbContext.SaveChangesAsync();
}