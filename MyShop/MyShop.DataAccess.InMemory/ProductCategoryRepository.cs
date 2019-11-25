using MySop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
   public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCatagories;
        public ProductCategoryRepository()
        {
            productCatagories = cache["productCatagories"] as List<ProductCategory>;
            if (productCatagories == null)
            {
                productCatagories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCatagories"] = productCatagories;

        }

        public void Insert(ProductCategory p)
        {
            productCatagories.Add(p);

        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCatagories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }


        }

        public ProductCategory Find(string Id)
        {
            ProductCategory ProductCategory = productCatagories.Find(p => p.Id == Id);
            if (ProductCategory  != null)
            {
                return ProductCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }


        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCatagories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory ProductCategoryToDelete = productCatagories.Find(p => p.Id == Id);
            if (ProductCategoryToDelete != null)
            {
                productCatagories.Remove(ProductCategoryToDelete);
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }




    }
}
