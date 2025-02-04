namespace ORM_Dapper;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public void CreateProduct(string name, double price, int categoryID);
    
    public void UpdateProduct(string name, double price, int productID, int OnSale, int StockLevel);
    
    public void DeleteProduct(int productID);
}