using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IProductsOnOrderDAL
    {
        //רשימת מוצרים בהזמנה
        public List<ProductsOnOrder> GetProductsOnOrders();
        //הוספת מוצר בהזמנה
        public List<ProductsOnOrder> AddproductsOnOrders(ProductsOnOrder productsOnOrder);
        //מחיקת מוצר מהזמנה
        public List<ProductsOnOrder> DeleteproductsOnOrders(int codePrductOnOrder);
        //עדכון  סטטוס מוצר בהזמנה
        public List<ProductsOnOrder> UpdateproductsOnOrders(int codePrductOnOrder);
        //עדכון  סטטוס כל המוצרים בהזמנה מסוימת 
        public List<ProductsOnOrder> UpdateproductsOnOrdersByCodeOrder (int codeOrder);
        //החזרת רשימת מוצרים בהזמנה על פי קוד הזמנה
        public List<ProductsOnOrder> GetProductsOnOrdersByCodeOrder(int codeOrder);
    }
}
