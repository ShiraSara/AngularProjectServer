using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;

namespace BL.Models
{
   public interface IProductsOnOrderBL
    {
        //רשימת מוצרים בהזמנה
        public List<ProductsOnOrderDTO> GetProductsOnOrders();
        //הוספת מוצר בהזמנה
        public List<ProductsOnOrderDTO> AddproductsOnOrders(ProductsOnOrderDTO productsOnOrder);
        //מחיקת מוצר מהזמנה
        public List<ProductsOnOrderDTO> DeleteproductsOnOrders(int codePrductOnOrder);
        //עדכון מוצר בהזמנה
        public List<ProductsOnOrderDTO> UpdateproductsOnOrders(int codePrductOnOrder);
        //החזרת רשימת מוצרים בהזמנה על פי קוד הזמנה
        public List<ProductsOnOrderDTO> GetProductsOnOrdersByCodeOrder(int codeOrder);
        //עדכון  סטטוס כל המוצרים בהזמנה מסוימת 
        public List<ProductsOnOrderDTO> UpdateproductsOnOrdersByCodeOrder(int codeOrder);

    }

}
