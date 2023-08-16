using InventoryAppEFCore.DataLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEFCoreContextInitializer
    {
        private readonly ILogger<InventoryAppEFCoreContextInitializer> logger;
        private readonly InventoryAppEfCoreContext context;


        public InventoryAppEFCoreContextInitializer(ILogger<InventoryAppEFCoreContextInitializer> logger, InventoryAppEfCoreContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (this.context.Database.IsSqlServer())
                {
                    await this.context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                #pragma warning disable CA1848 // Use the LoggerMessage delegates
                this.logger.LogError(ex, "An error occurred while initializing the database.");
                #pragma warning restore CA1848 // Use the LoggerMessage delegates
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await this.TrySeedAsync();
            }
            catch (Exception ex)
            {
                #pragma warning disable CA1848 // Use the LoggerMessage delegates
                this.logger.LogError(ex, "An error occurred while seeding the database.");
                #pragma warning restore CA1848 // Use the LoggerMessage delegates
                throw;
            }
        }
        public void InitializeUDF()
        {
            this.CreateScalarUdfForProductAverageVotes();
            this.CreateTableValuedUDF();
        }

        public async Task TrySeedAsync()
        {
            // Default data
            // Seed, if necessary
            if (!this.context.Products.Any())
            {
                this.context.Products.Add(new Product()
                {
                    Name = "Bag",
                });

                this.context.Products.Add(new Product()
                {
                    Name = "Shoes",
                });

                this.context.Products.Add(new Product()
                {
                    Name = "T-Shirt",
                });

                await this.context.SaveChangesAsync();
            }
            if (!this.context.PriceOffers.Any())
            {
                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 100,
                    PromotinalText = "10% Off",
                    ProductId = 1,
                    Currency = "Php"
                });

                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 200,
                    PromotinalText = "20% Off",
                    ProductId = 2,
                    Currency = "Php"

                });

                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 150,
                    PromotinalText = "30% Off",
                    ProductId = 3,
                    Currency = "Php"

                });

                await this.context.SaveChangesAsync();
            }
        }
        private void CreateScalarUdfForProductAverageVotes()
        {
            string UdfAverageVotes = nameof(UDFMethods.AverageVotes);

            this.context.Database.ExecuteSqlRaw(
                $"CREATE FUNCTION {UdfAverageVotes} (@productId int)" +
                @"  RETURNS float
                    AS
                    BEGIN
                        DECLARE @result as float
                        SELECT 
                            @result = AVG(CAST([NumStars] AS float))
                        FROM [dbo].[Reviews] AS r
                        WHERE r.ProductId = @productId
                    RETURN @result
                    END"
            );
        }

        private void CreateTableValuedUDF()
        {
            string GetProductNameAndReviewsFiltered = "GetProductNameAndReviewsFiltered";

            this.context.Database.ExecuteSqlRaw(
                $"CREATE FUNCTION {GetProductNameAndReviewsFiltered} ( @minReviews INT )" +
                @" RETURNS TABLE 
                    AS
                    RETURN 
                    (
	                    SELECT 
			                    [Name],
			                    COUNT(r.NumStars) [ReviewsCount],
			                    [dbo].[AverageVotes](p.ProductId) [AverageVotes]

	                    FROM [dbo].[Products] p
	                    INNER JOIN [dbo].[Reviews] r WITH (NOLOCK)
	                    ON r.ProductId = p.ProductId 
	                    WHERE r.NumStars >= @minReviews
	                    GROUP BY p.[ProductId], [Name]
                    )"
            );

        }
    }
}
