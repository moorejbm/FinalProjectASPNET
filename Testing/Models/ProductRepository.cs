using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {  
                _conn = conn;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetAllProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE driverID = @id",
                new { id = id });

        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, strokesGained = @strokesGained, totalDistanceRank = @totalDistanceRank, forgivenessRank = @forgivenessRank, URL = @URL, Price = @price WHERE driverID = @id",
                new { name = product.Name, strokesGained = product.StrokesGained, totalDistanceRank = product.TotalDistanceRank, forgivenessRank = product.ForgivenessRank, URL = product.URL, price = product.Price, id = product.driverID });
        }

        public void InsertProduct(Product productsToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, strokesGained, TOTALDISTANCERANK, FORGIVENESSRANK, URL, PRICE) VALUES (@name, @strokesgained, @totaldistancerank, @forgivenessrank, @URL, @price);",
                new { name = productsToInsert.Name, strokesgained = productsToInsert.StrokesGained, totaldistancerank = productsToInsert.TotalDistanceRank, forgivenessrank = productsToInsert.ForgivenessRank, URL = productsToInsert.URL, price = productsToInsert.Price });
        }

        /*public IEnumerable<Category> GetCategories()
        
            return _conn.Query<Category>("SELECT * FROM categories;");
        }*/

        /*public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;
        }*/
        public void DeleteProduct(Product product)
        {
            //_conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
                                       //new { id = products.driverID });
           //_conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                                       //new { id = products.driverID });
            _conn.Execute("DELETE FROM Products WHERE DriverID = @id;",
                                       new { id = product.driverID });
        }

        public IEnumerable<Product> SearchProduct(string search)
        {
            return _conn.Query<Product>("SELECT * FROM products where name LIKE @name",
            new { name = "%" + search + "%" });
        }

      
        public void InsertImage(Product product)
        {
            _conn.Execute("Update Products SET Image = @image WHERE DriverID = @driverid",
        new { image = product.Image, driverid = product.driverID });
        }
    }
}

