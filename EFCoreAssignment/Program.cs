// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = "Server=localhost;Database=EFCoreMasters.Session01;Trusted_Connection=True;"; // TODO : Add your connection string here
var optionsBuilder =
    new DbContextOptionsBuilder
           <AppDbContext>();
optionsBuilder.UseSqlServer(connection);

var options = optionsBuilder.Options;

var dbContext = new AppDbContext(options);

Filtering(dbContext);
SingleOrDefault(dbContext);
LoadingRelatedData_Manual(dbContext);
LoadingRelatedData_ExplicitLoading(dbContext);
LoadingRelatedData_EagerLoading(dbContext);

static void Filtering(AppDbContext dbContext)
{
    // TODO : Filter by Product Name
    var products = dbContext.Products
                    .Where(a => a.Name == "Mobile Phone")
                    .ToList();
}

static void SingleOrDefault(AppDbContext dbContext)
{
    // TODO : Select using SingleOrDefault by Product Id
    var product = dbContext.Products
                   .SingleOrDefault(a => a.Id == 1);
}

static void LoadingRelatedData_Manual(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data manually
    var product = dbContext.Products
                    .FirstOrDefault();
    if(product != null)
    {
        product.Shop = dbContext.Shops
            .Single(a => a.Id == product.ShopId);
    }
}

static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data explicitly
    var product = dbContext.Products
                    .FirstOrDefault();

    dbContext.Entry(product)
        .Reference(b => b.Shop)
        .Load();

    dbContext.Entry(product)
        .Collection(b => b.Reviews)
        .Load();
}

static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related Shop data eagerly
    var product = dbContext.Products
                    .Include(b => b.Shop)
                    .Include(b => b.Reviews)
                    .FirstOrDefault();
}


Console.WriteLine("EF Core is the best");
