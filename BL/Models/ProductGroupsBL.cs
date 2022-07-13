using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;
using AutoMapper;
using DAL.Models;
using DataObject;

namespace BL.Models
{
    public class ProductGroupsBL : IProductGroupsBL
    {
        IProductGroupsDAL _productGroupsDAL;
        IMapper iMapper;
        public ProductGroupsBL(IProductGroupsDAL productGroupsDAL)
        {
            _productGroupsDAL = productGroupsDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();
            });
            iMapper = config.CreateMapper();
        }
        //הוספת קבוצת מוצרים
        public List<ProductGroupsDTO> AddProductGroup(ProductGroupsDTO productGroups)
        {
            ProductGroups productGroups1 = iMapper.Map<ProductGroupsDTO, ProductGroups>(productGroups);
            List<ProductGroupsDTO> productGroupsDTOs = iMapper.Map<List<ProductGroups>, List<ProductGroupsDTO>>(_productGroupsDAL.AddProductGroup(productGroups1));
            return productGroupsDTOs;
        }
        //מחיקת קבוצת מוצרים
        public List<ProductGroupsDTO> DeleteProductGroup(int codeGroup)
        {
            List<ProductGroupsDTO> productGroupsDTOs = iMapper.Map<List<ProductGroups>, List<ProductGroupsDTO>>(_productGroupsDAL.DeleteProductGroup(codeGroup));
            return productGroupsDTOs;
        }
        //החזרת רשימת כל המוצרים
        public List<ProductGroupsDTO> GetProductGroups()
        {
            List<ProductGroupsDTO> productGroupsDTOs = iMapper.Map<List<ProductGroups>, List<ProductGroupsDTO>>(_productGroupsDAL.GetProductGroups());
            return productGroupsDTOs;
        }
        //החזרת קבוצת מוצרים ע"פ קוד קבוצה
        public string[] GetProductGroupsByCodeGroup(int codeGroup)
        {
            return _productGroupsDAL.GetProductGroupsByCodeGroup(codeGroup);
        }
        //עדדכון קבוצת מוצרים
        public List<ProductGroupsDTO> UpdateProductGroup(int codeGroup, ProductGroupsDTO p)
        {
            ProductGroups productGroups1 = iMapper.Map<ProductGroupsDTO, ProductGroups>(p);
            List<ProductGroupsDTO> productGroupsDTOs = iMapper.Map<List<ProductGroups>, List<ProductGroupsDTO>>(_productGroupsDAL.UpdateProductGroup(codeGroup,productGroups1));
            return productGroupsDTOs;
        }
    }
}
