using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            
    
            var newRepo = new DapperProductRepository(conn);

            Console.WriteLine("Product name:");
            var newName = Console.ReadLine();
            Console.WriteLine("Product price:");
            var newPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter product category ID:");
            var newCategory = int.Parse(Console.ReadLine());
            
            newRepo.CreateProduct(newName, newPrice, newCategory);
            
            var productList = newRepo.GetAllProducts();
            foreach (var product in productList)
            {
                Console.WriteLine($"Category ID: {product.CategoryID}, Name: {product.Name}, Price: {product.Price}");
            }
            
            Console.WriteLine("Please enter the product ID of the product you want to update:");
            var updatedID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new product name:");
            var updatedName = Console.ReadLine();
            Console.WriteLine("Enter new product price:");
            var updatedPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter current stock level:");
            var updatedStock = int.Parse(Console.ReadLine());
            Console.WriteLine("If product is on sale, enter 1. If not, enter 0:");
            var updatedOnSale = int.Parse(Console.ReadLine());
            
            newRepo.UpdateProduct(updatedName, updatedPrice, updatedID,updatedOnSale, updatedStock);
            
            Console.WriteLine("Product updated");
            
            Console.WriteLine("Please enter product ID of the product you want to delete:");
            var deleteID = int.Parse(Console.ReadLine());
            newRepo.DeleteProduct(deleteID);



        }
    }
}
