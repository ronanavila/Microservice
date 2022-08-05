using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogProductSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        bool existProduct = productCollection.Find(p => true).Any();

        if (!existProduct)
            productCollection.InsertManyAsync(GetProducts());
    }

    private static IEnumerable<Product> GetProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id ="5c1789948544bcbb51991985",
                Name = "Product1",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend.",
                Category ="PDCT",
                Price = 150.00m,
                Image ="Image-1.png"
            },
            new Product()
            {
                Id ="760109b97f430abe2755ae30",
                Name = "Product2",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend.",
                Category ="PDCT",
                Price = 120.20m,
                Image ="Image-2.png"
            },
            new Product()
            {
                Id ="44db0d0cd04acb8a035adb39",
                Name = "Product3",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend.",
                Category ="MCDA",
                Price = 20.50m,
                Image ="Image-3.png"
            },
            new Product()
            {
                Id ="79a6f2dfde48cfa0865624db",
                Name = "Product4",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend.",
                Category ="MCDA",
                Price = 80.88m,
                Image ="Image-4.png"
            },
            new Product()                                    {
                Id ="c930d7c8854cefa00b4d9f29",
                Name = "Product5",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend.",
                Category ="NPDC",
                Price = 33.33m,
                Image ="Image-5.png"
            },
            new Product()                                                    {
                Id ="b49507f5524401aedf497703",
                Name = "Product6",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend.",
                Category ="NMCD",
                Price = 500.00m,
                Image ="Image-6.png"
            }
        };
    }
}
