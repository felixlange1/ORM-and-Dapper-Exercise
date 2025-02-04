using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;
    
    public DapperProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products");
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@Name, @Price, @CategoryID);",
            new { Name = name, Price = price, CategoryID = categoryID });
    }

    public void UpdateProduct(string name, double price, int productID, int onSale, int stockLevel)
    {
        _connection.Execute(
            "UPDATE products SET Name = @name, Price = @price, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @productID",
            new { Name = name, Price = price, OnSale = onSale, StockLevel = stockLevel, ProductID = productID });
    }

    public void DeleteProduct(int productID)
    {
        _connection.Execute("DELETE FROM products WHERE ProductID = @productID",
            new { ProductID = productID });
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID",
            new { ProductID = productID });
        _connection.Execute("DELETE FROM sales WHERE ProductID = @productID",
            new { ProductID = productID });
    }
}