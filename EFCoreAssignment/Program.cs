// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using EFCoreAssignment.Entities;
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
InsertProduct(dbContext);
InsertProductWithNewShop(dbContext);
UpdateProduct(dbContext);
DeleteProduct(dbContext);
DeleteProductByKey(dbContext);

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

static void InsertProduct(AppDbContext dbContext)
{
    // TODO: Insert a new Product
    var product = new Product
    {
        Name = "Mouse Pad",
        ShopId = 2
    };

    dbContext.Add(product);
    dbContext.SaveChanges();
}

static void InsertProductWithNewShop(AppDbContext dbContext)
{
    // TODO: Insert a new Product with a new Shop
    var shop = new Shop
    {
        Name = "Instagram"
    };

    var product = new Product
    {
        Name = "Charger",
        Shop = shop
    };

    dbContext.Add(product);
    dbContext.SaveChanges();
}

static void UpdateProduct(AppDbContext dbContext)
{
    // TODO: Update a Product
    var productId = 5;

    var product = dbContext.Products
        .Include(p => p.Reviews)
        .Single(p => p.Id == productId);

    var review = new Review
    {
        ReviewerName = "Santa Cruz",
        Comment = "Super Big!",
        NumberOfStars = 5,
    };

    product.Reviews.Add(review);
    dbContext.SaveChanges();
}

static void DeleteProduct(AppDbContext dbContext)
{
    // TODO: Delete a Product
    var productId = 2;
    
    var product = dbContext.Products.Single(p => p.Id == productId);

    dbContext.Remove(product);
    dbContext.SaveChanges();
}

static void DeleteProductByKey(AppDbContext dbContext)
{
    // TODO: Delete a Product with just having a key
    var productId = 3;

    var product = new Product { Id = productId };

    dbContext.Remove(product);
    dbContext.SaveChanges();
}

Console.WriteLine("EF Core is the best");
