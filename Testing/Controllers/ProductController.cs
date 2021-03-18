using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace ASPNET.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;
        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var product = repo.GetAllProduct();

            return View(product);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetAllProduct(id);

            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetAllProduct(id);

            if (prod == null)
            {
                return View("ProductNotFound");
            }

            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.driverID });
        }

        public IActionResult InsertProduct()
        {
            //var prod = repo.AssignCategory();

            return View();
        }

        public IActionResult InsertProductToDataBase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);

            return RedirectToAction("Index");
        }

        public IActionResult Search(string searchString)
        {
            var search = repo.SearchProduct(searchString);

            return View(search);

        }

        public IActionResult UploadButtonClick(IFormFile files, Product product)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);
                    // Combines two strings into a path.
                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"{ newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        files.CopyTo(fs);
                        fs.Flush();
                    }

                    //ensures file path is correct
                    product.Image = "/images/" +newFileName;

                    //adds file path to our product
                    repo.InsertImage(product);
                }
            }
            // returns the index view
            return RedirectToAction("Index");
        }





    }
}

