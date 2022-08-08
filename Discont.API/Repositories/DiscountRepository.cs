using Dapper;
using Discont.API.Entities;
using Npgsql;

namespace Discont.API.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly IConfiguration _configuration;

    public DiscountRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        NpgsqlConnection connection = GetConnectionPostgreSQL();

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            ("SELECT * FROM Coupon WHERE ProductName = @ProductName",
            new { productName = productName });

        if (coupon is null)
            return new Coupon() { ProductName = "No Discount", Amount = 0, Description = "No Description" };

        return coupon;
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        NpgsqlConnection connection = GetConnectionPostgreSQL();

        var created = await connection.ExecuteAsync
            ("INSERT INTO Coupon (ProductName, Description, Amount)" +
            " VALUES (@ProductName, @Description, @Amount)",
            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

        if (created == 0)
            return false;

        return true;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        NpgsqlConnection connection = GetConnectionPostgreSQL();

        var updated = await connection.ExecuteAsync
            (" UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount " +
            " WHERE Id = @Id ",
            new
            {
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount,
                Id = coupon.Id
            });

        if (updated == 0)
            return false;

        return true;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        NpgsqlConnection connection = GetConnectionPostgreSQL();

        var deleted = await connection.ExecuteAsync
            ("DELETE FROM Coupon WHERE Productname = @ProductName",
            new { ProductName = productName });

        if (deleted == 0)
            return false;

        return true; ;
    }

    private NpgsqlConnection GetConnectionPostgreSQL()
    {
        return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
    }

}
