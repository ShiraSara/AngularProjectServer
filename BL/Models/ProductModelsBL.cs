using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DataObject.Models;
using AutoMapper;
using DataObject;

namespace BL.Models
{
   public class ProductModelsBL:IProductModelsBL
    {
        IProductModelsDAL _productModelsDAL;
        IMapper iMapper;
        public ProductModelsBL(IProductModelsDAL productModelsDAL)
        {
            _productModelsDAL = productModelsDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();
            });
            iMapper = config.CreateMapper();
        }
        //החזרת רשימת כל הדגמים
        public List<ProductModelsDTO> GetProductModels()
        {
            List<ProductModelsDTO> productModelsDTOs = iMapper.Map<List<ProductModels>, List<ProductModelsDTO>>(_productModelsDAL.GetProductModels());
            return productModelsDTOs;
        }
        //מחיקת דגם
        public List<ProductModelsDTO> DeleteProductModels(int codeModel)
        {
            return iMapper.Map<List<ProductModels>, List<ProductModelsDTO>>(_productModelsDAL.DeleteProductModels(codeModel));
        }
        //עדכון דגם
        public List<ProductModelsDTO> UpdateProductModels(int codeModel, ProductModelsDTO p)
        {
            ProductModels productModels = iMapper.Map<ProductModelsDTO, ProductModels>(p);
            return iMapper.Map<List<ProductModels>, List<ProductModelsDTO>>(_productModelsDAL.UpdateProductModels(codeModel,productModels));
        }
        //הוספת דגם
        public List<ProductModelsDTO> AddProductModels(ProductModelsDTO productModels)
        {
            ProductModels productModels1 = iMapper.Map<ProductModelsDTO, ProductModels>(productModels);
            return iMapper.Map<List<ProductModels>, List<ProductModelsDTO>>(_productModelsDAL.AddProductModels(productModels1));
        }
        //החזרת דגמים למוצר
        public List<ProductModelsDTO> GetProductModelsByCodeProduct(int code)
        {
            return iMapper.Map<List<ProductModels>, List<ProductModelsDTO>>(_productModelsDAL.GetProductModelsByCodeProduct(code));

        }
        //החזרת שם מוצר
        public string[] GetNameProduct(int codeModel)
        {
            return _productModelsDAL.GetNameProduct(codeModel);
        }
    }
}
