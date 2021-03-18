using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Models
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProduct();
        public Product GetAllProduct(int id);
        public void UpdateProduct(Product product);
        public void InsertProduct(Product productToInsert);
        //public IEnumerable<Category> GetCategories();
        //public Product AssignCategory();
        public void DeleteProduct(Product product);
        public IEnumerable<Product> SearchProduct(string search);
        public void InsertImage(Product product);

    }
    

}
