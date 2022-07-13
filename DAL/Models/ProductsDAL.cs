using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class ProductsDAL : IProductDAL
    {
        //הוספת מוצר
        public List<Products> AddProduct(Products products)
        {
            using(var Data=new DataProject())
            {
                Data.Products.Add(products);
                Data.SaveChanges();
                return Data.Products.ToList();
            }
        }
        //מחיקת מוצר
        public List<Products> DeleteProduct(int codeProduct)
        {
            using (var Data = new DataProject())
            {
                Products p = Data.Products.ToList().FirstOrDefault(p => p.CodeProduct == codeProduct);
                Data.Products.Remove(p);
                Data.SaveChanges();
                return Data.Products.ToList();
            }
        }

        //החזרת רשימת מוצרים במחסן- לפי קוד מחסן
        public List<Products> GetProductByCodeStorage(int codeStorage)
        {
            using(var Data= new DataProject())
            {
                List<Products> products = Data.Products.ToList().Where(p => p.CodeStorage == codeStorage).ToList();
                return products;
            }
        }
        //החזרת רשימת כל המוצרים
        public List<Products> GetProducts()
        {
            using (var Data = new DataProject())
            {
                return Data.Products.ToList();
            }
        }
        //עדכון מוצר
        public List<Products> UpdateProduct(int codeProduct, Products products)
        {
            using (var Data = new DataProject())
            {
                Products p = Data.Products.ToList().FirstOrDefault(p => p.CodeProduct == codeProduct);
                Products products1 = new Products();
                if(p!=null)
                {
                    products1.CodeProduct = codeProduct;
                    products1.CodeStorage = products.CodeStorage;
                    products1.CodeGroup = products.CodeGroup;
                    products1.NameProduct = products.NameProduct;
                    Data.Products.Remove(p);
                    Data.Products.Add(products1);
                    Data.SaveChanges();
                }
                return Data.Products.ToList();
            }
        }
        //החזרת דגמים לפי קוד קבוצה
        public List<Products> GetProductBtCodeGroup(int codeGroup)
        {
            using(var Data=new DataProject())
            {
                List<Products> products = Data.Products.Where(p => p.CodeGroup == codeGroup).ToList();
                return products;
            }
        }

        
    }
}
