using AutoMapper;
using DAL.Models;
using DataObject;
using DataObject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class ProductBL : IProductBL
    {
        IProductDAL _productsDAL;
        IMapper iMapper;
        public ProductBL(IProductDAL productsDAL)
        {
            _productsDAL = productsDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();
            });
            iMapper = config.CreateMapper();
        }
        //הוספת מוצר
        public List<ProductDTO> AddProduct(ProductDTO products)
        {
            Products products1 = iMapper.Map<ProductDTO, Products>(products);
            List<ProductDTO> productDTOs = iMapper.Map<List<Products>, List<ProductDTO>>(_productsDAL.AddProduct(products1));
            return productDTOs;
        }
        //מחיקת מוצר
        public List<ProductDTO> DeleteProduct(int codeProduct)
        {
            List<ProductDTO> productDTOs = iMapper.Map<List<Products>, List<ProductDTO>>(_productsDAL.DeleteProduct(codeProduct));
            return productDTOs;
        }

        //החזרת רשימת מוצרים במחסן- לפי קוד מחסן
        public List<ProductDTO> GetProductByCodeStorage(int codeStorage)
        {
            List<ProductDTO> productDTOs = iMapper.Map<List<Products>, List<ProductDTO>>(_productsDAL.GetProductByCodeStorage(codeStorage));
            return productDTOs;
        }
        //החזרת רשימת מוצרים
        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> productDTOs = iMapper.Map<List<Products>, List<ProductDTO>>(_productsDAL.GetProducts());
            return productDTOs;
        }
        //עדכון מוצר
        public List<ProductDTO> UpdateProduct(int codeProduct, ProductDTO products)
        {
            Products products1 = iMapper.Map<ProductDTO, Products>(products);
            List<ProductDTO> productDTOs = iMapper.Map<List<Products>, List<ProductDTO>>(_productsDAL.UpdateProduct(codeProduct,products1));
            return productDTOs;
        }
        //החזרת דגמים לפי קוד קבוצה
        public List<ProductDTO> GetProductBtCodeGroup(int codeGroup)
        {
            List<ProductDTO> productDTOs = iMapper.Map<List<Products>, List<ProductDTO>>(_productsDAL.GetProductBtCodeGroup(codeGroup));
            return productDTOs;
        }
    }
}
