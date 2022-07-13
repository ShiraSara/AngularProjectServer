using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IProductModelsDAL
    {
         //החזרת רשימת כל הדגמים
        public List<ProductModels> GetProductModels();
        //מחיקת דגם
        public List<ProductModels> DeleteProductModels(int codeModel);
        //עדכון דגם
        public List<ProductModels> UpdateProductModels(int codeModel, ProductModels p);
        //הוספת דגם
        public List<ProductModels> AddProductModels(ProductModels productModels);
        //החזרת דגמים למוצר
        public List<ProductModels> GetProductModelsByCodeProduct(int code);
        //החזרת שם מוצר
        public string[] GetNameProduct(int codeModel);
    }
}
