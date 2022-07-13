using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class ProductModelsDAL : IProductModelsDAL
    {
        //החזרת רשימת כל הדגמים
        public List<ProductModels> GetProductModels()
        {
            using (var Data = new DataProject())
            {
                return Data.ProductModels.ToList();
            }
        }
        //מחיקת דגם
        public List<ProductModels> DeleteProductModels(int codeModel)
        {
            using (var Data = new DataProject())
            {
                ProductModels productModels = Data.ProductModels.Where(p => p.CodeModel == codeModel).FirstOrDefault();
                Data.ProductModels.Remove(productModels);
                Data.SaveChanges();
                return Data.ProductModels.ToList();
            }
        }
        //עדכון דגם
        public List<ProductModels> UpdateProductModels(int codeModel, ProductModels p)
        {
            using (var Data = new DataProject())
            {
                ProductModels productModels = Data.ProductModels.Where(p => p.CodeModel == codeModel).FirstOrDefault();
                ProductModels productModels1 = new ProductModels();
                if(productModels!=null)
                {
                    productModels1.CodeModel = codeModel;
                    productModels1.CodeProduct = p.CodeProduct;
                    productModels1.Size = p.Size;
                    productModels1.Shelf = p.Shelf;
                    productModels1.Price = p.Price;
                    productModels1.Column = p.Column;
                    productModels1.CountInStock = p.CountInStock;
                    productModels1.Position = p.Position;
                    productModels1.CodeColor = p.CodeColor;
                    Data.ProductModels.Remove(productModels);
                    Data.ProductModels.Add(productModels1);
                    Data.SaveChanges();
                }
                return Data.ProductModels.ToList();
            }
        }
        //הוספת דגם
        public List<ProductModels> AddProductModels(ProductModels productModels)
        {
            using (var Data = new DataProject())
            {
                int code = Data.ProductModels.Max(productModels => productModels.CodeModel);
                productModels.CodeModel = code+1;
                Data.ProductModels.Add(productModels);
                Data.SaveChanges();
                return Data.ProductModels.ToList();
            }
        }
        //החזרת דגמים למוצר
        public List<ProductModels> GetProductModelsByCodeProduct(int code)
        {
            using(var Data=new DataProject())
            {
                List<ProductModels> productModels = Data.ProductModels.Where(p => p.CodeProduct == code).ToList();
                return productModels;
            }
        }
        //החזרת שם מוצר
        public string[] GetNameProduct(int codeModel)
        {
            string[] aa = new string[1];
            using (var Data = new DataProject())
            {
                int? code = Data.ProductModels.FirstOrDefault(p => p.CodeModel == codeModel).CodeProduct;
                aa[0] = Data.Products.FirstOrDefault(p => p.CodeProduct == code).NameProduct;
            }
            return aa;
        }
    }
}
