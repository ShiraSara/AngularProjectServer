using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;

namespace BL.Models
{
   public interface IProductModelsBL
    {
        //החזרת רשימת כל הדגמים
        public List<ProductModelsDTO> GetProductModels();
        //מחיקת דגם
        public List<ProductModelsDTO> DeleteProductModels(int codeModel);
        //עדכון דגם
        public List<ProductModelsDTO> UpdateProductModels(int codeModel, ProductModelsDTO p);
        //הוספת דגם
        public List<ProductModelsDTO> AddProductModels(ProductModelsDTO productModels);
        //החזרת דגמים למוצר
        public List<ProductModelsDTO> GetProductModelsByCodeProduct(int code);
        //החזרת שם מוצר
        public string[] GetNameProduct(int codeModel);
    }
}
