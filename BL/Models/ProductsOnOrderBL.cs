using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;
using DAL.Models;
using AutoMapper;
using DataObject;

namespace BL.Models
{
   public class ProductsOnOrderBL:IProductsOnOrderBL
    {
        IProductsOnOrderDAL _productsOnOrderDAL;
        IMapper iMapper;
        public ProductsOnOrderBL(IProductsOnOrderDAL productsOnOrderDAL)
        {
            _productsOnOrderDAL = productsOnOrderDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();
            });
            iMapper = config.CreateMapper();
        }

        //רשימת מוצרים בהזמנה
        public List<ProductsOnOrderDTO> GetProductsOnOrders()
        {
            return iMapper.Map<List<ProductsOnOrder>, List<ProductsOnOrderDTO>>(_productsOnOrderDAL.GetProductsOnOrders());
        }
        //הוספת מוצר בהזמנה
        public List<ProductsOnOrderDTO> AddproductsOnOrders(ProductsOnOrderDTO productsOnOrder)
        {
            ProductsOnOrder productsOnOrder1 = iMapper.Map<ProductsOnOrderDTO, ProductsOnOrder>(productsOnOrder);
            return iMapper.Map<List<ProductsOnOrder>, List<ProductsOnOrderDTO>>(_productsOnOrderDAL.AddproductsOnOrders(productsOnOrder1));
        }
        //מחיקת מוצר מהזמנה
        public List<ProductsOnOrderDTO> DeleteproductsOnOrders(int codePrductOnOrder)
        {
            return iMapper.Map<List<ProductsOnOrder>, List<ProductsOnOrderDTO>>(_productsOnOrderDAL.DeleteproductsOnOrders(codePrductOnOrder));
        }
        //עדכון סטטוס מוצר בהזמנה
        public List<ProductsOnOrderDTO> UpdateproductsOnOrders(int codePrductOnOrder)
        {
            return iMapper.Map<List<ProductsOnOrder>, List<ProductsOnOrderDTO>>(_productsOnOrderDAL.UpdateproductsOnOrders(codePrductOnOrder));
        }
        //החזרת רשימת מוצרים בהזמנה על פי קוד הזמנה
        public List<ProductsOnOrderDTO> GetProductsOnOrdersByCodeOrder(int codeOrder)
        {
            return iMapper.Map<List<ProductsOnOrder>, List<ProductsOnOrderDTO>>(_productsOnOrderDAL.GetProductsOnOrdersByCodeOrder(codeOrder));
        }
        //עדכון  סטטוס כל המוצרים בהזמנה מסוימת 
        public List<ProductsOnOrderDTO> UpdateproductsOnOrdersByCodeOrder(int codeOrder)
        {
            return iMapper.Map<List<ProductsOnOrder>, List<ProductsOnOrderDTO>>(_productsOnOrderDAL.UpdateproductsOnOrdersByCodeOrder(codeOrder));
        }
    }
}
